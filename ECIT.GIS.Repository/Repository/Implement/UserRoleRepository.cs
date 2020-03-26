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
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public bool AddUserRole(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserRole(PredicateGroup group)
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetUserRole(PredicateGroup group, PageQuery query)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserRole(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}