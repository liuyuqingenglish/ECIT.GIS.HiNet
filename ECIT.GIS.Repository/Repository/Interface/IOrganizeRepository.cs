/*
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

using ECIT.GIS.Entity;
using System.Collections.Generic;
using DapperExtensions;
using ECIT.GIS.Common;
using System;
namespace ECIT.GIS.Repository
{
    public interface IOrganizeRepository : IBaseRepository<Organization>
    {
        List<Organization> GetOrganize(PredicateGroup group,PageQuery query);
        bool AddOrganize(Organization org);

        bool UpdateOrganize(Organization org);

        bool DeleteOrganize(PredicateGroup group);
    }
}