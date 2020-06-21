/*
* ==============================================================================
*
* Filename: LoggerHelper
* ClrVersion: 4.0.30319.42000
* Description: LoggerHelper
*
* Version: 1.0
* Created: 2020/4/10 9:44:46
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/
using NLog;
using System;
namespace ECIT.GIS.Common
{
   
    public class LoggerHelper
    {
        private static LoggerHelper logHelper;
        private static Logger logger;

        public static LoggerHelper GetIntance()
        {
            if (logHelper == null)
            {
                logHelper = new LoggerHelper();
            }
            if (logger == null)
            {
                logger = LogManager.GetCurrentClassLogger();
            }
            return logHelper;
        }
        public void Debug(string error, Exception ex)
        {
            logger.Debug(error, ex,null);
        }
        public void Debug(string error)
        {
            logger.Debug(error);
        }
        public void Error(string error, Exception ex)
        {
            logger.Error(error, ex, null);
        }
        public void Warn(string error, Exception ex)
        {
            logger.Warn(error, ex, null);
        }
    }
}