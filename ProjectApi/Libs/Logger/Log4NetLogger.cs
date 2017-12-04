using System;
using System.Collections.Generic;
using System.Text;
using log4net;


namespace Logger
{
    public class Log4NetLogger : BusinessLogic.ServiceAPI.ILogger
    {
        private ILog logger;

        internal Log4NetLogger(ILog log4netLogger = null)
        {
            this.logger = log4netLogger ?? LogManager.GetLogger("DefaultLogger");
        }

        public void Info(String text, params object[] placeholder)
        {
            logger.InfoFormat(text, placeholder);
        }

        public void Info(Exception e, String text, params object[] placeholder)
        {
            logger.Info(String.Format(text, placeholder), e);
        }

        public void Debug(String text, params object[] placeholder)
        {
            logger.DebugFormat(text, placeholder);
        }

        public void Debug(Exception e, String text, params object[] placeholder)
        {
            logger.Debug(String.Format(text, placeholder), e);
        }

        public void Fatal(String text, params object[] placeholder)
        {
            logger.FatalFormat(text, placeholder);
        }

        public void Fatal(Exception e, String text, params object[] placeholder)
        {
            logger.Fatal(String.Format(text, placeholder), e);
        }

        public void Warning(String text, params object[] placeholder)
        {
            logger.WarnFormat(text, placeholder);
        }

        public void Warning(Exception e, String text, params object[] placeholder)
        {
            logger.Warn(String.Format(text, placeholder), e);
        }

        public void Error(String text, params object[] placeholder)
        {
            logger.ErrorFormat(text, placeholder);
        }

        public void Error(Exception e, String text, params object[] placeholder)
        {
            logger.Error(String.Format(text, placeholder), e);
        }
    }
}
