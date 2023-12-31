﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Settings
{
    public static class StaticInfos
    {
        public static string MsSqlConnectionString;
        public static string MySqlConnectionString;
        public static string PostgreSqlConnectionString;
        public static string OracleConnectionString;
        public static bool IsMsSQL;
        public static bool IsMySQL;
        public static bool IsPostgreSQL;
        //JWT
        public static string JwtKey;
        public static string JwtIssuer;
        public static string JwtAudience;
    }
}
