using System.Data;

namespace DeToiServer.Services.CleanupService
{
    public class RecordCleanupService : IRecordCleanupService
    {
        private readonly IDbConnection _dbConnection; // Inject your database connection here

        public RecordCleanupService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void DeleteOldBiddingRecords()
        {
            // Execute the DELETE statement
            using var command = _dbConnection.CreateCommand();
            command.CommandText = "dbo.DeleteOldBiddingRecords";
            command.CommandType = CommandType.StoredProcedure;
            _dbConnection.Open();
            command.ExecuteNonQuery();
        }
    }
}
