/*
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
using System.Linq;

namespace ECIT.GIS.Repository
{
    public class SystemRepository : BaseRepository<ECIT.GIS.Entity.System>, ISystemRepository
    {
        public bool AddSystem(Entity.System sys)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSystem(PredicateGroup group)
        {
            throw new NotImplementedException();
        }

        public List<Entity.System> GetSystem(PredicateGroup group, PageQuery query)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSystem(Entity.System sys)
        {
            throw new NotImplementedException();
        }
    }
}