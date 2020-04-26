using System;
using System.Collections.Generic;
using SqlSugar;
using System.Text;
using MyDotNetCore.Project.Infrastructure.Common;

namespace MyDotNetCore.Project.Infrastructure.Repositories
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
            IsAutoCloseConnection = false

        };
    }
}
