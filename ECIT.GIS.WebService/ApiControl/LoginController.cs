using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using ECIT.GIS.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ECIT.GIS.Common;
using System.IO;
namespace ECIT.GIS.WebService.ApiControl
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly IUserAccountService userService = null;

        public LoginController(IUserAccountService service)
        {
            userService = service;
        }
        [Route("GetRandomCode"), HttpGet]
        public IHttpActionResult GetRandomCode(string randomId)
        {
            ValidationCodeHelper helper = new ValidationCodeHelper();
            string code = helper.CreateCode(2, 4);
            RedisHelper.SetString(randomId, code, 2000);
            byte[] stream = helper.CreateImage(code);
            return new FileStreamContent(new MemoryStream(stream), "application/octet-stream");
        }
    }
}