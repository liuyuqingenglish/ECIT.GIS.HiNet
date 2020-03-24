using DapperExtensions.Mapper;

namespace ECIT.GIS.Entity
{
    /// <summary>
    /// 模块
    /// </summary>
    public class RolePermission : BaseEntity
    {
        /// <summary>
        /// 给XPath设默认值
        /// </summary>
        public RolePermission()
        {
        }

        /// <summary>
        /// 组织id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 模型id
        /// </summary>
        public int ModuleId { get; set; }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public sealed class RolePermissionMapper : ClassMapper<RolePermission>
    {
        /// <summary>
        /// DepartmentMapper
        /// </summary>
        public RolePermissionMapper()
        {
            Table("RolePermission");
            Map(x => x.Remark).Ignore();
            Map(x => x.Name).Ignore();
            Map(x => x.IsDelete).Ignore();
            Map(x => x.Disable).Ignore();
            AutoMap();
        }
    }
}