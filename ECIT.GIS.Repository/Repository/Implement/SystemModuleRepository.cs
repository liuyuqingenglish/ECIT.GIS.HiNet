﻿/*
* ==============================================================================
*
* Filename: DepartmentRepository
* ClrVersion: 4.0.30319.42000
* Description: DepartmentRepository
*
* Version: 1.0
* Created: 2019/12/26 17:21:49
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using ECIT.GIS.Common;
using ECIT.GIS.Entity;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Repository
{
    public class SystemModuleRepository : BaseRepository<SystemModule>, ISystemModuleRepository
    {
        public bool AddSystemModule(SystemModule module)
        {
            return base.Insert(module);
        }

        public bool DeleteSystemModule(PredicateGroup group)
        {
            throw new NotImplementedException();
        }

        public List<Entity.System> GetSystemModule(PredicateGroup group, PageQuery query)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSystemModule(SystemModule module)
        {
            throw new NotImplementedException();
        }
    }
}