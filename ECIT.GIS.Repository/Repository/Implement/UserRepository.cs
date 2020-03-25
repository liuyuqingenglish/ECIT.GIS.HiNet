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

namespace ECIT.GIS.Repository
{
    public class UserRepository : BaseRepository<UserAccount>, IUserRepository
    {
        public bool AddUserAccount(UserAccount depart)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserAccount(PredicateGroup group)
        {
            throw new NotImplementedException();
        }

        public List<UserAccount> GetDepartment(PredicateGroup group, PageQuery query)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserAccount(UserAccount depart)
        {
            throw new NotImplementedException();
        }
    }
}