/*
* ==============================================================================
*
* Filename: DbConnectFactory
* ClrVersion: 4.0.30319.42000
* Description: DbConnectFactory
*
* Version: 1.0
* Created: 2019/12/26 15:49:03
* Compiler: Visual Studio 2017
*
* Author: liuyuqing
* Copyright: 广东满天星云信息技术有限公司
*
* ==============================================================================
*/

using DapperExtensions.Sql;
using ECIT.GIS.Common;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
namespace ECIT.GIS.Repository
{
    public class DbConnectFactory
    {
        public static string ConnectString = "PORT=5432;DATABASE=ECIT;HOST=localhost;PASSWORD=123456;USER ID=postgres;";

        public static IDbConnection CreateDbConnect<T>(DataBasebType type) where T : IDbConnection, new()
        {
            switch (type)
            {
                case DataBasebType.Postgresql:
                    DapperExtensions.DapperExtensions.SqlDialect = new PostgreSqlDialect();
                    break;

                case DataBasebType.MySql:
                    DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
                    break;

                case DataBasebType.Oracel:
                    DapperExtensions.DapperExtensions.SqlDialect = new OracleDialect();
                    break;

                case DataBasebType.SQL:
                    DapperExtensions.DapperExtensions.SqlDialect = new SqlCeDialect();
                    break;
            }
            IDbConnection connect = new T();
            connect.ConnectionString = ConnectString;
            return connect;
        }

        public static IDbConnection GetPostgresqlConnection()
        {
            return CreateDbConnect<NpgsqlConnection>(DataBasebType.Postgresql);
        }
        public static IDbConnection GetSqlServerConnection()
        {
            return CreateDbConnect<SqlConnection>(DataBasebType.SQL);
        }
    }
}