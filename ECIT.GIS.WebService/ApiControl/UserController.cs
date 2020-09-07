using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using ECIT.GIS.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ECIT.GIS.WebService.ApiControl
{
    [RoutePrefix("api/User")]
    public class UserController : BaseController<MessageHub>
    {
        private readonly IUserAccountService departmentService = null;

        public UserController(IUserAccountService service)
        {
            departmentService = service;
        }
    }
}