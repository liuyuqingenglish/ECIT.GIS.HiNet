﻿/*
* ==============================================================================
*
* Filename: QueryDepartment
* ClrVersion: 4.0.30319.42000
* Description: QueryDepartment
*
* Version: 1.0
* Created: 2020/3/28 14:41:53
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECIT.GIS.Common;
namespace ECIT.GIS.Protocol
{
    public class ProtocolQueryUserAccount
    {
        public string OrganizeId{ get; set; }

        public string DepartmentId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public PageQuery Query { get; set; }
    }
}
