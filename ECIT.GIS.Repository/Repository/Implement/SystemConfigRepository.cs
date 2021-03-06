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
using System.Collections.Generic;
using System.Linq;

namespace ECIT.GIS.Repository
{
    public class SystemConfigRepository : BaseRepository<SystemConfig>, ISystemConfigRepository
    {
        public bool AddSystemConfig(SystemConfig config)
        {
            return base.Insert(config);
        }

        public bool DeleteSystemConfig(PredicateGroup group)
        {
            return base.Delete(group);
        }

        public List<SystemConfig> GetSystemConfig(PredicateGroup group, PageQuery query)
        {
            return base.GetPager(group, query).ToList();
        }

        public bool UpdateSystemConfig(SystemConfig config)
        {
            return base.Update(config);
        }
    }
}