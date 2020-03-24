/*
* ==============================================================================
*
* Filename: BaseRepository
* ClrVersion: 4.0.30319.42000
* Description: BaseRepository
*
* Version: 1.0
* Created: 2019/12/26 16:23:32
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions;
using ECIT.GIS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ECIT.GIS.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public bool Delete(T t)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.Delete<T>(t);
            }
        }

        public IList<T> GetList()
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.GetList<T>().ToList();
            }
        }

        public IList<T> GetListById(PredicateGroup group)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.GetList<T>(group).ToList();
            }
        }

        public bool Insert(T t)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.Insert<T>(t);
            }
        }

        public void Transaction(Action<IDbConnection> action)
        {
            using (var conn = DbConnectFactory.GetPostgresqlConnection())
            {
                var transaction = conn.BeginTransaction();
                try
                {
                    action(conn);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public TResult TransactionResult<TResult>(Func<IDbConnection, TResult> funData)
        {
            using (var conn = DbConnectFactory.GetPostgresqlConnection())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();
                try
                {
                    var result = funData(conn);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool Update(T t)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.Update<T>(t);
            }
        }

        void IBaseRepository<T>.Transaction(Action<IDbConnection> action)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPager(PredicateGroup group,List<SortType> order)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return  conn.GetPage<T>(group, order.ConvertToSort<T>(),1,1).ToList();
            }
        }

    }
}