using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeToiServer.Dtos
{
    public class LoginSocialRequestDto
    {
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Provider { get; set; } = string.Empty;

        [Required]
        public string AccessToken { get; set; } = string.Empty;
    }

    public class FacebookAppAccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
    }

    public class GoogleAccessTokenResponse
    {
        [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

        [JsonPropertyName("id_token")] public string? IdToken { get; set; }

        [JsonPropertyName("expires_in")] public int? ExpiresIn { get; set; }

        [JsonPropertyName("token_type")] public string? TokenType { get; set; }

        [JsonPropertyName("scope")] public string? Scope { get; set; }

        [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    }

    public class FacebookTokenValidationResult
    {
        [JsonPropertyName("data")] public FacebookTokenValidationData Data { get; set; } = null!;
    }

    public class FacebookTokenValidationData
    {
        [JsonPropertyName("app_id")] public string AppId { get; set; } = null!;

        [JsonPropertyName("type")] public string Type { get; set; } = null!;

        [JsonPropertyName("application")] public string Application { get; set; } = null!;

        [JsonPropertyName("data_access_expires_at")] public int DataAccessExpiresAt { get; set; }

        [JsonPropertyName("expires_at")] public int ExpiresAt { get; set; }

        [JsonPropertyName("is_valid")] public bool IsValid { get; set; }

        [JsonPropertyName("scopes")] public List<string> Scopes { get; set; } = null!;

        [JsonPropertyName("user_id")] public string UserId { get; set; } = null!;
    }
}
