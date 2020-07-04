/*
* ==============================================================================
*
* Filename: IBaseRepository
* ClrVersion: 4.0.30319.42000
* Description: IBaseRepository
*
* Version: 1.0
* Created: 2019/12/26 15:45:26
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using ECIT.GIS.Common;
using ECIT.GIS.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace ECIT.GIS.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        bool Insert(T t);

        bool Delete(PredicateGroup group);

        IList<T> GetList();

        IList<T> GetList(PredicateGroup group);

        IList<T> GetPager(PredicateGroup group, PageQuery query);

        bool Update(T t);

        bool Delete(T t);

        void Transaction(Action<IDbConnection> action);

        List<T> TransactionResult<T>(string sql) where T : new();

        bool ExcuteSqlWithTransaction(string sql);

        T GetD(Guid id);

        List<T> GetList(string sql);

        T Get(string sql);
    }
}