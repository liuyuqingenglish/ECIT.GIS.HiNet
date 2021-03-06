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
using System;
namespace ECIT.GIS.Entity
{
    public class SystemModuleDto : BaseDto
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
}