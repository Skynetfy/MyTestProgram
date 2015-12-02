using System;
using NLog;

namespace HZLogger.NLogWrapper
{
    public class HZLogger 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Trace(string msg)
        {
            logger.Trace(msg);
        }

        public static void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public static void Warn(string msg)
        {
            logger.Warn(msg);
        }

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

        public static void Error(string msg)
        {
            logger.Error(msg);
        }

        public static void Error(Exception exception, string message = "")
        {
            logger.ErrorException(message, exception);
        }

        public static void Fatal(string msg)
        {
            logger.Fatal(msg);
        }
    }
}
