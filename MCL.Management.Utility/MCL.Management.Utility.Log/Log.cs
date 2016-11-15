using log4net;
using System;
namespace MCL.Management.Utility.Log
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log
    {
        private ILog logger;
        public Log(ILog log)
        {
            this.logger = log;
        }
        public void Debug(object message)
        {
            if (AppSettingsHelper.GetBoolValue("IsLog"))
            {
                this.logger.Debug(message);
            }
            
        }
        public void Error(object message)
        {
            if (AppSettingsHelper.GetBoolValue("IsLog"))
            {
                this.logger.Error(message);
            }
        }
        public void Info(object message)
        {
            if (AppSettingsHelper.GetBoolValue("IsLog"))
            {
                this.logger.Info(message);
            }
        }
        public void Warn(object message)
        {
            if (AppSettingsHelper.GetBoolValue("IsLog"))
            {
                this.logger.Warn(message);
            }
        }
    }
}
