namespace CleanArchitecture.Domain
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }

        public const string default_username = "admin";
        public const string default_email = "admin@secureapi.com";
        public const string default_password = "admin";
        public const Roles default_role = Roles.Administrator;
    }
}