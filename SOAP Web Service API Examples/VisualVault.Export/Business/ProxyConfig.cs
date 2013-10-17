namespace VisualVault.Export.Business
{
    public class ProxyConfig
    {
        public string ServerUrl { get; set; }

        public int Port { get; set; }

        public bool UseIeConfiguration { get; set; }

        public bool UseWindowsCredentials { get; set; }

        public bool BypassProxyOnLocal { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
