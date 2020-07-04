using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using ECIT.GIS.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepartment")]
        public List<DepartmentDto> GetDepartment(ProtocolQueryDepartment query)
        {
            return departmentService.GetDepartmentDto(query);
        }

        /// <summary>
        /// 增加部门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddDepartment")]
        public bool AddDepartment(DepartmentDto depart)
        {
            return departmentService.AddDepartment(depart);
        }

        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditDepartment")]
        public bool EditDepartment(DepartmentDto depart)
        {
            return departmentService.UpdateDepartment(depart);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteDepartment")]
        public bool DeleteDepartment(Guid id)
        {
            return departmentService.DeleteDepartment(id);
        }

        [HttpPost]
        public string test([FromBody] string name)
        {
            return string.Empty;
        }

        [HttpPost]
        public string test1(JObject name)
        {
            return string.Empty;
        }
    }
}