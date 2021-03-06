﻿using DapperExtensions.Mapper;
using System;

namespace ECIT.GIS.Entity
{
    /// <summary>
    /// 部门
    /// </summary>
    public class SystemModule : BaseEntity
    {
        /// <summary>
        /// 系统id
        /// </summary>
        public Guid SystemId { get; set; }

        /// <summary>
        /// 模型id
        /// </summary>
        public Guid ModuleId { get; set; }

    }

    /// <summary>
    /// Mapper
    /// </summary>
    public sealed class SystemModuleMapper : ClassMapper<SystemModule>
    {
        /// <summary>
        /// OrganizationMapper
        /// </summary>
        public SystemModuleMapper()
        {
            ///映射表名
            Table("SystemModule");
            ///指定主键
            Map(x => x.Id).Key(KeyType.Guid);
            Map(x => x.Name).Ignore();
            Map(x => x.IsDelete).Ignore();
            Map(x => x.Disable).Ignore();
            ///忽略remark列
            //Map(x => x.Remark).Ignore();
            ///自动映射
            AutoMap();
        }
    }
}