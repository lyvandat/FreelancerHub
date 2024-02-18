namespace DeToiServer
{
    #pragma warning disable CS8618
    public class OAuthSecret
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class LoginSocialSecret
    {
        public OAuthSecret Google { get; set; }
        public OAuthSecret Facebook { get; set; }
    }

    public class GeoCodingSecret
    {
        public string ApiKey { get; set; }
    }

    public class ApplicationSecretSettings
    {
        public LoginSocialSecret LoginSocial { get; set; }
        public GeoCodingSecret GeoCoding { get; set; }
    }
}
