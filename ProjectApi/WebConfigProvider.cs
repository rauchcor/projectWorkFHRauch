using System.Configuration;
using System.Web.Configuration;
using BusinessLogic.ServiceAPI;

namespace ProjectApi
{
    public class WebConfigProvider : IConfigProvider
    {
        public const string ControllersPrefix = "api/";
        private const string LogPrefix = "log.";
        public const string AuthenticationPrefix = ControllersPrefix + "auth";
        public const string SpsTags = "spstag";
        public const string ChargenInfo = ControllersPrefix + "chargenPoolInfos";
        public const string ChargenPool = ControllersPrefix + "chargenPools";
        public const string Fertigungsauftraege = ControllersPrefix + "fertigungsauftraege";
        public const string PrintChargePrefix = "print";

        private string GetSettingOrDefault(string key) => WebConfigurationManager.AppSettings[key] ?? "";
        public string GetMinimumLogLevel() => GetSettingOrDefault(LogPrefix + "level");
        public string GetLogFileBase() => GetSettingOrDefault(LogPrefix + "filePathBase");
 
        public string GetWebServerUrl() => GetSettingOrDefault("serverUrl");
        public string GetWWWRoot() => GetSettingOrDefault("wwwRoot");
    }
}
