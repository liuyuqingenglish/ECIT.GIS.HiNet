using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface IRolePermissonService
    {
        List<RolePermissionDto> GetRolePermissionDto(ProtocolQueryRolePermision query);

        bool UpdateRolePermission(RolePermissionDto dto);
    }
}