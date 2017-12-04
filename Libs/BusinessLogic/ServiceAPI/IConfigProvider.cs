using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ServiceAPI
{
    public interface IConfigProvider
    {
        string GetMinimumLogLevel();
        string GetLogFileBase();
        string GetWebServerUrl();
        string GetWWWRoot();
    }
}
