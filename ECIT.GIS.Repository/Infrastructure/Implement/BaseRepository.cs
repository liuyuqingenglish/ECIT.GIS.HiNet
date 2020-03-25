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

using Dapper;
using DapperExtensions;
using ECIT.GIS.Common;
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

        public bool Delete(PredicateGroup group)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.Delete<T>(group);
            }
        }

        public IList<T> GetList()
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.GetList<T>().ToList();
            }
        }

        public IList<T> GetList(PredicateGroup group)
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

        public void Transaction(Predicate<IDbConnection> action)
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

        public void Transaction(Action<IDbConnection> action)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPager(PredicateGroup group, PageQuery query)
        {
            using (IDbConnection conn = DbConnectFactory.GetPostgresqlConnection())
            {
                return conn.GetPage<T>(group, query.OrderType.ConvertToSort<T>(), query.PageIndex - 1, query.PageCount).ToList();
            }
        }

        public bool ExcuteSqlWithTransaction(string sql)
        {
            using (var conn = DbConnectFactory.GetPostgresqlConnection())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();
                try
                {
                    int result = conn.Execute(sql);
                    transaction.Commit();
                    return result > 0;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}