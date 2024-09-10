
namespace WeeekDotNetHelper
{
    public interface IAppSettings
    {
        string WeeekApiToken { get; }
        Uri WeeekApiUrl { get; }
    }
}