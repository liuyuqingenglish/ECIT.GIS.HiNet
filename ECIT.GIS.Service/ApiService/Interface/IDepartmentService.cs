using System;
using System.Collections;
using System.Collections.Generic;
using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
namespace ECIT.GIS.Service
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetDepartmentDto(ProtocolQueryDepartment query);

        bool AddDepartment(DepartmentDto dto);

        bool UpdateDepartment(DepartmentDto dto);

        bool DeleteDepartment(Guid depid);
    }
}