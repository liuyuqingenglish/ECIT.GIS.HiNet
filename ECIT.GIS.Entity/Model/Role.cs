using DapperExtensions.Mapper;

namespace ECIT.GIS.Entity
{
    /// <summary>
    /// 模块
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// 给XPath设默认值
        /// </summary>
        public Role()
        {
        }

        /// <summary>
        /// 组织id
        /// </summary>
        public int OrganizationId { get; set; }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public sealed class RoleMapper : ClassMapper<Role>
    {
        /// <summary>
        /// DepartmentMapper
        /// </summary>
        public RoleMapper()
        {
            Table("Role");
            AutoMap();
        }
    }
}