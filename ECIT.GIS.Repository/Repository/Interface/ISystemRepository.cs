﻿/*
* ==============================================================================
*
* Filename: IDepartmentRepository
* ClrVersion: 4.0.30319.42000
* Description: IDepartmentRepository
*
* Version: 1.0
* Created: 2019/12/26 17:22:15
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using ECIT.GIS.Common;
using System.Collections.Generic;

namespace ECIT.GIS.Repository
{
    public interface ISystemRepository : IBaseRepository<ECIT.GIS.Entity.System>
    {
        List<ECIT.GIS.Entity.System> GetSystem(PredicateGroup group, PageQuery query);

        bool AddSystem(ECIT.GIS.Entity.System sys);

        bool UpdateSystem(ECIT.GIS.Entity.System sys);

        bool DeleteSystem(PredicateGroup group);
    }
}