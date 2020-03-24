/*
* ==============================================================================
*
* Filename: JwtHelper
* ClrVersion: 4.0.30319.42000
* Description: JwtHelper
*
* Version: 1.0
* Created: 2020/1/15 14:23:30
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.Collections.Generic;

namespace ECIT.GIS.Common
{
    public class JwtHelper
    {
        /// <summary>
        /// 加密方式
        /// </summary>
        private static IJwtAlgorithm jwtAlgorithm;

        /// <summary>
        /// base64加解密
        /// </summary>
        private static IBase64UrlEncoder base64Encrpty;

        /// <summary>
        /// 序列化对象
        /// </summary>
        private static IJsonSerializer serializer;

        /// <summary>
        /// 密匙
        /// </summary>
        private const string SECRET = "SDFASDFASDFSDF";

        /// <summary>
        /// 时间
        /// </summary>
        private static IDateTimeProvider provider;

        static JwtHelper()
        {
            jwtAlgorithm = new HMACSHA256Algorithm();
            base64Encrpty = new JwtBase64UrlEncoder();
            serializer = new JsonNetSerializer();
            provider = new UtcDateTimeProvider();
        }

        public static string CreateJwt(Dictionary<string, object> payload)
        {
            IJwtEncoder encoder = new JwtEncoder(jwtAlgorithm, serializer, base64Encrpty);
            return encoder.Encode(payload, SECRET);
        }

        public static bool VaildJwt(string token, out string payload, out string message)
        {
            try
            {
                message = "";
                payload = "";
                IJwtValidator vaild = new JwtValidator(serializer, provider);
                IJwtDecoder decoder = new JwtDecoder(serializer, vaild, base64Encrpty);
                payload = decoder.Decode(token, SECRET, true);
                return true;
            }
            catch (TokenExpiredException)
            {
                message = "过期了";
                payload = "";
                return false;
            }
            catch (SignatureVerificationException)
            {
                message = "验证错误";
                payload = "";
                return false;
            }
          
        }
    }
}