﻿/*
* ==============================================================================
*
* Filename: DepartmentDto
* ClrVersion: 4.0.30319.42000
* Description: DepartmentDto
*
* Version: 1.0
* Created: 2020/1/11 14:31:37
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

namespace ECIT.GIS.Entity
{
    public class DepartmentDto : BaseDto
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizeName;

        /// <summary>
        /// 父部门名称
        /// </summary>
        public string ParentName { get; set; }
    }
}