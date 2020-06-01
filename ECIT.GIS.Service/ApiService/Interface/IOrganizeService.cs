using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface IOrganizeService
    {
        List<OrganizationDto> GetOrganizeDto(ProtocolQueryOrganize query);

        bool AddOrganize(OrganizationDto dto);

        bool UpdateOrganize(OrganizationDto dto);

        bool DeleteOrganize(List<Guid> orgId);
    }
}