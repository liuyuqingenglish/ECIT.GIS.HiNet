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
using System.Text;

namespace ECIT.GIS.Repository
{
    public class RolePerssionRepository : BaseRepository<RolePermission>, IRolePerssionRepository
    {
        public bool AddRolePerssion(RolePermission rolePerssion)
        {
            return base.Insert(rolePerssion);
        }

        public bool DeleteRolePerssion(PredicateGroup group)
        {
            return base.Delete(group);
        }

        public List<RolePermission> GetRolePerssion(PredicateGroup group, PageQuery query)
        {
            return base.GetPager(group, query).ToList();
        }

        public bool UpdateRolePerssion(RolePermission rolePerssion)
        {
            return base.Update(rolePerssion);
        }
    }
}