﻿using DapperExtensions.Mapper;

namespace ECIT.GIS.Entity
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Organization : BaseEntity
    {
        public Organization():base()
        {
        }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public sealed class OrganizationMapper : ClassMapper<Organization>
    {
        /// <summary>
        /// OrganizationMapper
        /// </summary>
        public OrganizationMapper()
        {
            ///映射表名
            Table("Organization");
            ///指定主键
            Map(x => x.Id).Key(KeyType.Guid);
            ///忽略remark列
            //Map(x => x.Remark).Ignore();
            ///自动映射
            AutoMap();
        }
    }
}