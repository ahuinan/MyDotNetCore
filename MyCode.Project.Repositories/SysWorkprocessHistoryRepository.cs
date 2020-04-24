using MyDotNetCore.Project.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDotNetCore.Project.Domain.Model;
using MyDotNetCore.Project.Domain.Repositories;
using SqlSugar;

namespace MyDotNetCore.Project.Repositories
{
    public class SysWorkprocessHistoryRepository: Repository<sys_workprocess_history>, ISysWorkprocessHistoryRepository
    {
        public SysWorkprocessHistoryRepository(ISqlSugarClient context) : base(context)
        { }

      


	

	}
}