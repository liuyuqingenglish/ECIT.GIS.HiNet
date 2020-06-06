using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface ISystemModuleService
    {
        List<SystemModule> GetRoleDto(ProtocolQuerySystemModule query);

        bool AddRole(SystemModuleDto dto);

        bool UpdateRole(SystemModuleDto dto);

        bool DeleteRole(List<Guid> moduleId);
    }
}