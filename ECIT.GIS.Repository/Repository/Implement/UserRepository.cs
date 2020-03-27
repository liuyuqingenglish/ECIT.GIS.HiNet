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
using System.Collections;
using System.Linq;
namespace ECIT.GIS.Repository
{
    public class UserRepository : BaseRepository<UserAccount>, IUserRepository
    {
        public bool AddUserAccount(UserAccount user)
        {
            return base.Insert(user);
        }

        public bool DeleteUserAccount(PredicateGroup group)
        {
            return base.Delete(group);
        }

        public List<UserAccount> GetDepartment(PredicateGroup group, PageQuery query)
        {
            return base.GetPager(group, query).ToList();
        }

        public bool UpdateUserAccount(UserAccount user)
        {
            return base.Update(user);
        }
    }
}