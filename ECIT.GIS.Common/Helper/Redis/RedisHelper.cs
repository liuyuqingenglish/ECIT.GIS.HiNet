/*
* ==============================================================================
*
* Filename: RedisHelper
* ClrVersion: 4.0.30319.42000
* Description: RedisHelper
*
* Version: 1.0
* Created: 2020/1/15 14:23:46
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using CSRedis;

namespace ECIT.GIS.Common
{
    public class RedisHelper
    {
        private static CSRedisClient mRedisInstance = null;

        static RedisHelper()
        {
            if (mRedisInstance == null)
            {
                mRedisInstance = new CSRedisClient(ConfigData.redisConnectStr);
            }
        }

        public static bool SetString(string key, string value, int timeout = -1)
        {
            return mRedisInstance.Set(key, value, timeout);
        }

        public static string GetString(string key)
        {
            return mRedisInstance.Get(key);
        }

        public static long DelKey(string key)
        {
            return mRedisInstance.Del(key);
        }
    }
}