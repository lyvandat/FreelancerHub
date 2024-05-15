using StackExchange.Redis;
using System.Text.Json;

namespace DeToiServer.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly ILogger<CacheService> _logger;
        IDatabase? _cacheDb;

        public CacheService(ILogger<CacheService> logger) 
        {
            _logger = logger;

            try
            {
                var redis = ConnectionMultiplexer.Connect("redis-16071.c56.east-us.azure.redns.redis-cloud.com:16071,password=***");
                _cacheDb = redis.GetDatabase();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Cannot connect to Redis: {ex.Message}");
            }
        }

        public T? GetData<T>(string key)
        {
            if (_cacheDb == null) return default;

            var value = _cacheDb.StringGet(key).ToString();

            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public bool RemoveData(string key)
        {
            if (_cacheDb == null) return false;

            var exist = _cacheDb.KeyExists(key);

            if (exist)
                return _cacheDb.KeyDelete(key);

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            if (_cacheDb == null) return false;

            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);

            var isSet = _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expiryTime);

            return isSet;
        }
    }
}
