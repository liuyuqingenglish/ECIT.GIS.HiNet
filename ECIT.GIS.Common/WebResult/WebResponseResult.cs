/*
* ==============================================================================
*
* Filename: WebResponseResult
* ClrVersion: 4.0.30319.42000
* Description: WebResponseResult
*
* Version: 1.0
* Created: 2020/4/10 10:54:27
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

namespace ECIT.GIS.Common.WebResult
{
    public class WebResponseResult<TResult>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string Code;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess;

        /// <summary>
        /// 失败原因
        /// </summary>
        public string ErrorInfo;

        /// <summary>
        /// 返回实体
        /// </summary>
        public object Entity;

        public WebResponseResult(string code, bool success, object entity, string error)
        {
            this.Code = code;
            this.IsSuccess = success;
            this.Entity = entity;
            this.ErrorInfo = error;
        }
    }
}