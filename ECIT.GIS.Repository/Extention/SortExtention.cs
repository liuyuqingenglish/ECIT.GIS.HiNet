/*
* ==============================================================================
*
* Filename: SortExtention
* ClrVersion: 4.0.30319.42000
* Description: SortExtention
*
* Version: 1.0
* Created: 2020/3/24 16:23:21
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ECIT.GIS.Common;
namespace ECIT.GIS.Repository
{
    public static class SortExtention
    {
        public static List<ISort> ConvertToSort<T>(this List<SortType> list)
        {
            List<ISort> sortList = new List<ISort>();
            Type temp = typeof(T);
            List<FieldInfo> fields = temp.GetFields().ToList();
            foreach (SortType item in list)
            {
                if (fields.Any(x => x.Name.Equals(item.SortName)))
                {
                    Sort sort = new Sort();
                    sort.PropertyName = item.SortName;
                    sort.Ascending = item.AscOrder;
                    sortList.Add(sort);
                }
            }
            return sortList;
        }
    }


}