namespace broker.Models
{
    public static class YahooFinanceSettings
    {
        public static string? baseurl{ get; private set; }
        public static string? x_rapidAPI_host{ get; private set; }
        public static string? x_rapidAPI_key { get; private set; }

        public static void Configure(IConfigurationSection section)
        {
            baseurl = section.GetValue<string> ("baseurl");
            x_rapidAPI_host = section.GetValue<string> ("X-RapidAPI-Host");
            x_rapidAPI_key = section.GetValue<string> ("X-RapidAPI-Key");
        }
    }
}
