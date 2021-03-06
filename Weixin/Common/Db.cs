﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Weixin.Common
{
    public class Db
    {
        public static SqlConnection Create()
        {
            return new SqlConnection(ConfigHelper.ConnectionString);
        }

        public static int ExeSql(string strSql, Dapper.DynamicParameters parameters = null)
        {
            using (SqlConnection con = Db.Create())
            {
                con.Open();
                return con.Execute(strSql, parameters, null, null, CommandType.Text);
            }
        }

        public static IEnumerable<T> Query<T>(string strSql, Dapper.DynamicParameters parameters = null)
        {
            using (SqlConnection con = Db.Create())
            {
                con.Open();
                return con.Query<T>(strSql, parameters, null, true, null, CommandType.Text);
            }
        }

        public static int ExeProc(string procName, Dapper.DynamicParameters parameters = null)
        {
            using (SqlConnection con = Db.Create())
            {
                con.Open();
                return con.Execute(procName, parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public static int ExeProc<T>(string procName, T parameters)
        {
            using (SqlConnection con = Db.Create())
            {
                con.Open();
                return con.Execute(procName, parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<T> QueryProc<T>(string procName, Dapper.DynamicParameters parameters = null)
        {
            using (SqlConnection con = Db.Create())
            {
                con.Open();
                return con.Query<T>(procName, parameters, null, true, null, CommandType.StoredProcedure);
            }
        }
    }
}