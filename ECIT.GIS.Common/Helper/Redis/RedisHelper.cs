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

        public static CSRedisClient GetInstance()
        {
            if (mRedisInstance == null)
            {
                mRedisInstance = new CSRedisClient(ConfigData.redisConnectStr);
            }
            return mRedisInstance;
        }

        public bool SetString(string key, string value, int timeout = -1)
        {
            return mRedisInstance.Set(key, value, timeout);
        }

        public string GetString(string key)
        {
            return mRedisInstance.Get(key);
        }

        public long DelKey(string key)
        {
            return mRedisInstance.Del(key);
        }
    }
}