namespace DeToiServer
{
    #pragma warning disable CS8618
    public class SocialSecret
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class ApplicationSecretSettings
    {
        public SocialSecret Google { get; set; }
        public SocialSecret Facebook { get; set; }
    }
}
