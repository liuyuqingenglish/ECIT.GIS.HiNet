using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECIT.GIS.Repository
{
   public interface IUnitOfWork
    {
        IOrganizeRepository OrganizeRepositiry { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ISystemRepository SystemRepository { get; }
        ISystemModuleRepository SystemModuleRepository { get; }
        ISystemConfigRepository SystemConfigRepository { get; }
        IRoleRepository RoleRepository { get; }
        IModuleRepository ModuleRepository { get; }
    }
}
