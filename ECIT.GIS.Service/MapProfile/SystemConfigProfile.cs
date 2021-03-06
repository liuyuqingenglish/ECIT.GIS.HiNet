﻿/*
* ==============================================================================
*
* Filename: DepartmentProfile
* ClrVersion: 4.0.30319.42000
* Description: DepartmentProfile
*
* Version: 1.0
* Created: 2020/1/11 14:29:04
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using AutoMapper;
using ECIT.GIS.Entity;
namespace ECIT.GIS.Service
{
    public class SystemConfigProfile : Profile
    {
        public SystemConfigProfile()
        {
            CreateMap<SystemConfig, SystemConfigDto>();
            CreateMap<SystemConfigDto, SystemConfig>();
        }
    }
}