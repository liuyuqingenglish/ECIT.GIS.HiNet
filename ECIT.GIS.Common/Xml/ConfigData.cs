/*
* ==============================================================================
*
* Filename: ConfigData
* ClrVersion: 4.0.30319.42000
* Description: ConfigData
*
* Version: 1.0
* Created: 2020/5/27 11:51:03
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

namespace ECIT.GIS.Common
{
    public class ConfigData
    {
        /// <summary>
        /// redis
        /// </summary>
        public static readonly string redisConnectStr = "RedisConnectStr".GetConfigData();

        /// <summary>
        /// postgresql
        /// </summary>
        public static readonly string postgresConnectStr = "PostgresqlConnectStr".GetConfigData();
    }
}