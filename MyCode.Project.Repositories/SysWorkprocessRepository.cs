using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDotNetCore.Project.Domain.Model;
using MyDotNetCore.Project.Domain.Repositories;
using MyDotNetCore.Project.Repositories.Common;
using MyCode.Project.Domain.Repositories;
using SqlSugar;

namespace MyDotNetCore.Project.Repositories
{
    public class SysWorkprocessRepository: Repository<sys_workprocess>, ISysWorkprocessRepository
    {
        public SysWorkprocessRepository(ISqlSugarClient context) : base(context)
        { }

      


	

	}
}