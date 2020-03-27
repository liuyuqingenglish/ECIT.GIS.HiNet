/*
* ==============================================================================
*
* Filename: DepartmentService
* ClrVersion: 4.0.30319.42000
* Description: DepartmentService
*
* Version: 1.0
* Created: 2020/1/11 9:03:15
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using ECIT.GIS.Entity;
using ECIT.GIS.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ECIT.GIS.Service
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unit) : base(unit)
        {
        }

        public List<DepartmentDto> GetDto()
        {
            List<Department> list = Unit.DepartmentRepository.GetDepartmentList();
            List<DepartmentDto> dto = new List<DepartmentDto>();
            foreach (Department item in list)
            {
                dto.Add(item.ToDto<DepartmentDto>());
            }
            return dto;
        }
    }
}