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
using System;
using System.Net;
namespace ECIT.GIS.Common
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

        public WebResponseResult(TResult result)
        {
            this.Code = HttpStatusCode.OK.ToString();
            this.IsSuccess = true;
            this.Entity = result;
        }
        public WebResponseResult()
        {
            this.Code= HttpStatusCode.OK.ToString();
            this.Entity = new object();
            this.IsSuccess = true;
            this.ErrorInfo = string.Empty;
        }
        public WebResponseResult(string errorInfo)
        {
            this.Code = HttpStatusCode.BadRequest.ToString();
            this.IsSuccess = false;
            this.ErrorInfo = errorInfo;
        }
        public WebResponseResult(Exception ex)
        {
            this.Code = HttpStatusCode.BadRequest.ToString();
            this.IsSuccess = false;
            this.ErrorInfo = ex.Message;
        }
    }
}