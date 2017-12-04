using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.ServiceAPI;

namespace DemoSelfHostedWebApi
{
    public class AppConfigProvider : IConfigProvider
    {
        public const string ControllersPrefix = "api/";

        private string GetSettingOrDefault(string key) => ConfigurationManager.AppSettings[key] ?? "";

        public string GetMinimumLogLevel() => GetSettingOrDefault("logLevel");
        public string GetLogFileBase() => GetSettingOrDefault("logFilePathBase");
        public string GetWebServerUrl() => GetSettingOrDefault("serverUrl");
        public string GetWWWRoot() => GetSettingOrDefault("wwwRoot");
    }
}
