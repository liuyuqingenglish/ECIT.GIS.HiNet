/*
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

        public IOrganizeRepository OrganizeRepositiry => ResolveRepository<IOrganizeRepository>();

        public IUserRepository UserRepository => ResolveRepository<IUserRepository>();

        public IUserRoleRepository UserRoleRepository => ResolveRepository<IUserRoleRepository>();

        public ISystemRepository SystemRepository => ResolveRepository<ISystemRepository>();

        public ISystemModuleRepository SystemModuleRepository => ResolveRepository<ISystemModuleRepository>();

        public ISystemConfigRepository SystemConfigRepository => ResolveRepository<ISystemConfigRepository>();

        public IRoleRepository RoleRepository => ResolveRepository<IRoleRepository>();

        public IModuleRepository ModuleRepository => ResolveRepository<IModuleRepository>();

        public IRolePerssionRepository RolePerssionRepository => ResolveRepository<IRolePerssionRepository>();
        private TRepository ResolveRepository<TRepository>() where TRepository : class
        {
            return liftlineScore.Resolve<TRepository>();
        }
    }
}