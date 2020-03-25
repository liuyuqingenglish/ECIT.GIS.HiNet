/*
* ==============================================================================
*
* Filename: PageQuery
* ClrVersion: 4.0.30319.42000
* Description: PageQuery
*
* Version: 1.0
* Created: 2020/3/25 11:33:46
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/
using System;
using System.Collections;
using System.Collections.Generic;
namespace ECIT.GIS.Common
{
    public class PageQuery
    {
        /// <summary>
        /// 排序
        /// </summary>
        public List<SortType> OrderType { get; set; }
        /// <summary>
        /// 分页下标
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数
        /// </summary>
        public int PageCount { get; set; }
    }

    public class SortType
    {
        /// <summary>
        /// 排序名称
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// 是否升序排序
        /// </summary>
        public bool AscOrder { get; set; }
    }
}