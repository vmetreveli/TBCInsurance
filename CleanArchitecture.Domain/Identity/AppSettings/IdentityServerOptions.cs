namespace CleanArchitecture.Common.AppSettings
{
    public class IdentityServerOptions
    {
        public string Authority { get; set; }

        public string AuthClientId { get; set; }

        public string AuthClientSecret { get; set; }

        public string AuthScope { get; set; }

        public bool RequireHttpsMetadata { get; set; }
    }
}