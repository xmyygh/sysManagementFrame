using System;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Utility;
using MCL.Management.Client.Cache;
using MCL.Management.Utility.Log;

namespace MCL.Management.App.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 控制器方法中出现异常，会调用该方法捕获异常,错误写到日志中
        /// </summary>
        /// <param name="context">提供使用</param>
        public override void OnException(ExceptionContext context)
        {
            WriteLog(context);
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }

        /// <summary>
        /// 写入日志（log4net）
        /// </summary>
        /// <param name="context">提供使用</param>
        private void WriteLog(ExceptionContext context)
        {
            
            if (context == null)
                return;
            if (CurrentUserProvider.Provider.IsOverdue())
                return;
            var log = LogFactory.GetLogger(context.Controller.ToString());
            Exception Error = context.Exception;
            LogMessage logMessage = new LogMessage();
            logMessage.OperationTime = DateTime.Now;
            logMessage.Url = HttpContext.Current.Request.RawUrl;
            logMessage.Class = context.Controller.ToString();
            logMessage.Ip = WebHelper.Ip;
            logMessage.Host = WebHelper.Host;
            logMessage.Browser = WebHelper.Browser;
            logMessage.UserName = CurrentUserProvider.Provider.GetCurrentUser().Account + "（" + CurrentUserProvider.Provider.GetCurrentUser().UserName + "）";
            if (Error.InnerException == null)
            {
                logMessage.ExceptionInfo = Error.Message;
            }
            else
            {
                logMessage.ExceptionInfo = Error.InnerException.Message;
            }

            string strMessage = new LogFormat().ExceptionFormat(logMessage);
            log.Error(strMessage);
        }
    }
}