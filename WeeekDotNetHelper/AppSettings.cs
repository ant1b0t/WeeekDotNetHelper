namespace WeeekDotNetHelper
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;
        public Uri WeeekApiUrl => new Uri(_configuration["WeeekApi:ApiUrl"]);
        public string WeeekApiToken => _configuration["WeeekApi:Token"];


        public AppSettings(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
    }
}
