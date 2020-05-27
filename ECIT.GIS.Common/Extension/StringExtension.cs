/*
* ==============================================================================
*
* Filename: StringExtension
* ClrVersion: 4.0.30319.42000
* Description: StringExtension
*
* Version: 1.0
* Created: 2020/5/27 11:45:18
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using System.Configuration;

namespace ECIT.GIS.Common
{
    public static class StringExtension
    {
        public static string GetConfigData(this string configKey, string defaultData = null)
        {
            if (ConfigurationManager.AppSettings[configKey] != null)
            {
                return ConfigurationManager.AppSettings[configKey].ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(defaultData))
                {
                    return defaultData;
                }
            }
            return string.Empty;
        }
    }
}