using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface ISystemModuleService
    {
        List<ModuleDto> GetSystemModuleDto(ProtocolQuerySystemModule query);

        bool UpdateSystemModule(ModuleDto dto);
    }
}