﻿/*
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

using DapperExtensions;
using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using ECIT.GIS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECIT.GIS.Service
{
    public class SystemService : BaseService, ISystemService
    {
        public SystemService(IUnitOfWork unit) : base(unit)
        {
        }

        public bool AddSystem(SystemDto dto)
        {
            return Unit.SystemRepository.AddSystem(dto.ToModel<ECIT.GIS.Entity.System>());
        }

        public bool DeleteSystem(Guid sysid)
        {
            PredicateGroup group = new PredicateGroup();
            group.Predicates.Add(Predicates.Field<ECIT.GIS.Entity.System>(d => d.Id, Operator.Eq, sysid));
            return Unit.SystemRepository.Delete(group);
        }

        public List<SystemDto> GetSystemDto(ProtocolQuerySystem query)
        {
            PredicateGroup group = new PredicateGroup();
            if (!string.IsNullOrEmpty(query.SystemId))
            {
                group.Predicates.Add(Predicates.Field<Department>(d => d.Id, Operator.Eq, query.SystemId));
            }
            if (!string.IsNullOrEmpty(query.SystemName))
            {
                group.Predicates.Add(Predicates.Field<Department>(d => d.Name, Operator.Eq, query.SystemName));
            }
            return Unit.SystemRepository.GetSystem(group, query.Query).ToListDto<ECIT.GIS.Entity.System, SystemDto>().ToList();
        }

        public bool UpdateSystem(SystemDto dto)
        {
            return Unit.SystemRepository.UpdateSystem(dto.ToModel<ECIT.GIS.Entity.System>());
        }
    }
}