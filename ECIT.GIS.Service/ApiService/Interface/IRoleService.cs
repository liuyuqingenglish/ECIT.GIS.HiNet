using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface IRoleService
    {
        List<RoleDto> GetRoleDto(ProtocolQueryRole query);

        bool AddRole(RoleDto dto);

        bool UpdateRole(RoleDto dto);

        bool DeleteRole(List<Guid> roleId);
    }
}