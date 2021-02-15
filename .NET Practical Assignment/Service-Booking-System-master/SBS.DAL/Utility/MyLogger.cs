using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Utility
{
    public class MyLogger : ILogger
    {
        private static MyLogger instance;
        private static Logger logger;

        private MyLogger()
        {

        }


        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger("appLoggerRules").Debug(message);
        }

        public void Error(string message)
        {
            GetLogger("appLoggerRules").Error(message);
        }

        public void Info(string message)
        {
            GetLogger("appLoggerRules").Info(message);
        }

        public void Warn(string message)
        {
            GetLogger("appLoggerRules").Warn(message);
        }
    }
}
