using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ServiceAPI
{
    public interface ILogger
    {
        void Info(Exception ex, string messageTemplate, params object[] messageValues);
        void Info(string messageTemplate, params object[] messageValues);
        void Debug(Exception ex, string messageTemplate, params object[] messageValues);
        void Debug(string messageTemplate, params object[] messageValues);
        void Warning(Exception ex, string messageTemplate, params object[] messageValues);
        void Warning(string messageTemplate, params object[] messageValues);
        void Error(Exception ex, string messageTemplate, params object[] messageValues);
        void Error(string messageTemplate, params object[] messageValues);
        void Fatal(Exception ex, string messageTemplate, params object[] messageValues);
        void Fatal(string messageTemplate, params object[] messageValues);
    }
}
