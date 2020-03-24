using ECIT.GIS.Common;
using ECIT.GIS.Entity;
using ECIT.GIS.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ECIT.GIS.WebService.ApiControl
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService = null;

        public DepartmentController(IDepartmentService service)
        {
            departmentService = service;
        }

        [HttpGet]
        [Route("Get")]
        public List<DepartmentDto> Get(string token)
        {
            string pay;
            string message;
            if (JwtHelper.VaildJwt(token, out pay, out message))
            {
                return departmentService.GetDto();
            }
            else
            {
                return new List<DepartmentDto>();
            }
        }

        [HttpGet]
        [Route("GetToken")]
        public string GetToken()
        {
            var payload = new Dictionary<string, object>()
            {
                { "iss","流月无双"},
                { "exp",DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds()},
                {"sub","testjwt"},//主题
                { "aud","user"},//用户
                { "iat",DateTime.Now.ToString()},//发布时间
                { "data",new { name="lyq",sex="man",age="12"} }
            };
            return JwtHelper.CreateJwt(payload);
            //string pay;
            //string message;
            //JwtHelper.VaildJwt(json, out pay, out message);

        }
    }
}