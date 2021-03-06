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
using ECIT.GIS.Entity;
namespace ECIT.GIS.Repository
{
    public interface ISystemModuleRepository : IBaseRepository<SystemModule>
    {
        List<ECIT.GIS.Entity.System> GetSystemModule(PredicateGroup group, PageQuery query);

        bool AddSystemModule(SystemModule module);

        bool UpdateSystemModule(SystemModule module);

        bool DeleteSystemModule(PredicateGroup group);
    }
}