using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface ISystemService
    {
        List<SystemDto> GetSystemDto(ProtocolQuerySystem query);

        bool AddSystem(SystemDto dto);

        bool UpdateSystem(SystemDto dto);

        bool DeleteSystem(Guid sysId);
    }
}