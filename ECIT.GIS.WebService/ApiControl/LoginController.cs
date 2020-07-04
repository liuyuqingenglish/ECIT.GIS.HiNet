using ECIT.GIS.Common;
using ECIT.GIS.Entity;
using ECIT.GIS.Service;
using System;
using System.IO;
using System.Web.Http;

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

        [AllowAnonymous]
        public bool CheckVaildCode(string visitedkey, string code)
        {
            if (code.Equals(RedisHelper.GetString(visitedkey)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Login")]
        public UserAccountDto Login(UserAccount account, string returnUrl)
        {
            UserAccountDto dto = userService.GetUserDto(account.Account, account.Password);
            if (dto == null)
            {
                throw new Exception("用户不存在");
            }
            return dto;
        }
    }
}