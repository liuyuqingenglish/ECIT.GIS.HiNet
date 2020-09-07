using ECIT.GIS.Common;
using ECIT.GIS.Entity;
using ECIT.GIS.Service;
using System;
using System.IO;
using System.Web.Http;

namespace ECIT.GIS.WebService.ApiControl
{
    [RoutePrefix("api/Login")]
    public class LoginController : BaseController<MessageHub>
    {
        private readonly IUserAccountService userService = null;

        public LoginController(IUserAccountService service)
        {
            userService = service;
        }

        public LoginController()
        { }

        [Route("GetRandomCode"), HttpGet]
        [AllowSkip, AllowAnonymous]
        public IHttpActionResult GetRandomCode(string randomId)
        {
            ValidationCodeHelper helper = new ValidationCodeHelper();
            string code = helper.CreateCode(2, 4);
            RedisHelper.SetString(randomId, code, 120);
            byte[] stream = helper.CreateImage(code);
            return new FileStreamContent(new MemoryStream(stream), "application/octet-stream");
        }

        [HttpPost]
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
        public UserAccountDto Login(UserAccountDto account)
        {
            UserAccountDto dto = userService.GetUserDto(account.Account, account.Password);
            if (dto == null)
            {
                throw new Exception("用户不存在");
            }
            dto.Modules = userService.GetUserRolePermission(account.Id);
            if (!string.IsNullOrEmpty(RedisHelper.GetString(dto.WebToken)))
            {
                return dto;
            }
            if (account.IsRemain)
            {
                dto.ExpireTime = DateTime.Now.AddDays(7);
            }
            else
            {
                dto.ExpireTime = DateTime.Now.AddDays(1);
            }
            RedisHelper.SetString(dto.WebToken, dto.ToJson(), Convert.ToInt32((dto.ExpireTime - DateTime.Now).TotalSeconds));
            return dto;
        }

        [HttpPost, AllowAnonymous]
        public string test()
        {
            return "sf";
        }
    }
}