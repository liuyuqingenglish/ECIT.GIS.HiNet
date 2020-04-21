/*
* ==============================================================================
*
* Filename: JsonHelper
* ClrVersion: 4.0.30319.42000
* Description: JsonHelper
*
* Version: 1.0
* Created: 2020/4/13 8:52:44
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
namespace ECIT.GIS.Common
{
   public static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static object ToObject(this string json)
        {
            return JsonConvert.DeserializeObject(json);
        }
        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
