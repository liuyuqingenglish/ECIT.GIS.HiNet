/*
* ==============================================================================
*
* Filename: DepartmentService
* ClrVersion: 4.0.30319.42000
* Description: DepartmentService
*
* Version: 1.0
* Created: 2020/1/11 9:03:15
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using ECIT.GIS.Entity;
using ECIT.GIS.Protocol;
using ECIT.GIS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECIT.GIS.Service
{
    public class UserAccountService : BaseService, IUserAccountService
    {
        public UserAccountService(IUnitOfWork unit) : base(unit)
        {
        }

        public bool AddUserAccount(UserAccountDto dto)
        {
            return Unit.SystemRepository.AddSystem(dto.ToModel<ECIT.GIS.Entity.System>());
        }

        public bool DeleteUserAccount(List<Guid> orgid)
        {
            PredicateGroup group = new PredicateGroup();
            group.Operator = GroupOperator.And;
            foreach (Guid item in orgid)
            {
                group.Predicates.Add(Predicates.Field<ECIT.GIS.Entity.System>(d => d.Id, Operator.Eq, item));
            }
            return Unit.SystemRepository.Delete(group);
        }

        public List<UserAccountDto> GetUserAccountDto(ProtocolQueryUserAccount query)
        {
            PredicateGroup group = new PredicateGroup();
            group.Operator = GroupOperator.And;
            if (!string.IsNullOrEmpty(query.OrganizeId))
            {
                group.Predicates.Add(Predicates.Field<UserAccount>(d => d.OrganizationId, Operator.Eq, query.OrganizeId));
            }
            if (!string.IsNullOrEmpty(query.DepartmentId))
            {
                group.Predicates.Add(Predicates.Field<UserAccount>(d => d.DepartmentId, Operator.Eq, query.DepartmentId));
            }
            if (!string.IsNullOrEmpty(query.UserId))
            {
                group.Predicates.Add(Predicates.Field<UserAccount>(d => d.Id, Operator.Eq, query.UserId));
            }
            if (!string.IsNullOrEmpty(query.UserName))
            {
                group.Predicates.Add(Predicates.Field<UserAccount>(d => d.Name, Operator.Like, query.UserName));
            }
            return Unit.UserRepository.GetUserAccount(group, query.Query).ToListDto<ECIT.GIS.Entity.UserAccount, UserAccountDto>().ToList();
        }

        public bool UpdateUserAccount(UserAccountDto dto)
        {
            return Unit.UserRepository.UpdateUserAccount(dto.ToModel<ECIT.GIS.Entity.UserAccount>());
        }

        public UserAccountDto GetUserDto(string account, string password)
        {
            return Unit.UserRepository.GetUserAccount(account, password).ToDto<UserAccountDto>();
        }

        public List<RolePermissionDto> GetUserRolePermission(Guid userid)
        {
            PredicateGroup group = new PredicateGroup();
            group.Predicates.Add(Predicates.Field<UserRole>(u => u.UserId, Operator.Eq, userid));
            List<UserRole> roleList = Unit.UserRoleRepository.GetList(group).ToList();
            StringBuilder sql = new StringBuilder();
            foreach (UserRole item in roleList)
            {
                sql.Append($"{item.RoleId},");
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append($"select * from RolePerssion where {RolePermissonService.ROLE_ID} in ({sql.ToString()})");
            return Unit.RoleRepository.GetList<RolePermission>(sql.ToString()).ToListDto<RolePermission, RolePermissionDto>();
        }
    }
}