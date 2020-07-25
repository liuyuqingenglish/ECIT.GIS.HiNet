using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using System;
using System.Collections.Generic;

namespace ECIT.GIS.Service
{
    public interface IUserAccountService
    {
        List<UserAccountDto> GetUserAccountDto(ProtocolQueryUserAccount query);

        bool AddUserAccount(UserAccountDto dto);

        bool UpdateUserAccount(UserAccountDto dto);

        bool DeleteUserAccount(List<Guid> userId);
        UserAccountDto GetUserDto(string account, string password);

        List<RolePermissionDto> GetUserRolePermission(Guid userId);
    }
}