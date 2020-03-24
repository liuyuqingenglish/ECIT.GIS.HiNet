﻿/*
* ==============================================================================
*
* Filename: UnitOfWork
* ClrVersion: 4.0.30319.42000
* Description: UnitOfWork
*
* Version: 1.0
* Created: 2020/1/11 8:44:18
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using Autofac;

namespace ECIT.GIS.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ILifetimeScope liftlineScore;

        public UnitOfWork(ILifetimeScope score)
        {
            liftlineScore = score;
        }

        public IDepartmentRepository DepartmentRepository => ResolveRepository<IDepartmentRepository>();

        private TRepository ResolveRepository<TRepository>() where TRepository : class
        {
            return liftlineScore.Resolve<TRepository>();
        }
    }
}