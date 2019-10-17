namespace Farmacity.FCDM.BackOffice.Configuration
{
    public class SecurityConfiguration
    {
        public bool AuthenticationEnabled { get; set; }
        public string CorsOrigins { get; set; }
        public bool RequireSsl { get; set; }
        public string SigningKey { get; set; }
        public string SigningCredentialsName { get; set; }
    }
}