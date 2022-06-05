namespace broker.Models
{
    public static class SmtpSettings
    {
        public static string? login { get; private set; }
        public static string? password { get; private set; }
        public static int port { get; private set; }
        public static string? hostname { get; private set; }

        public static void Configure(IConfigurationSection section)
        {
            login = section.GetValue<string> ("login");
            password = section.GetValue<string> ("password");
            port = section.GetValue<int> ("port");
            hostname = section.GetValue<string> ("hostname");
        }
    }
}
