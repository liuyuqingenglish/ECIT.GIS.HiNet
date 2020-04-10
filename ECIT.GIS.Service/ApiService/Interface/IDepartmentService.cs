using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

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