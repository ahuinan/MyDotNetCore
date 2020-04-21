using System;
using System.Collections.Generic;
using SqlSugar;
using System.Text;
using MyDotNetCore.Project.Domain.Common;

namespace MyDotNetCore.Project.Repositories.Common
{
    public class MyDotNetCoreSqlSugarClient: SqlSugarClient
    {
        public MyDotNetCoreSqlSugarClient() : base(config)
        {

        }

        private static ConnectionConfig config = new ConnectionConfig()
        {
            ConnectionString = SysConfig.ConnectionMasterStr,
            DbType = DbType.MySql,
            InitKeyType = InitKeyType.Attribute,
            IsAutoCloseConnection = true

        };
    }
}
