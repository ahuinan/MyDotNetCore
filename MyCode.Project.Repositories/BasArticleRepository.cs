using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDotNetCore.Project.Domain.Repositories;
using MyDotNetCore.Project.Domain.Model;
using MyDotNetCore.Project.Repositories.Common;
using MyCode.Project.Domain.Repositories;

namespace MyDotNetCore.Project.Repositories
{
    public class BasArticleRepository: Repository<bas_article>, IBasArticleRepository
    {
        public BasArticleRepository(MyDotNetCoreSqlSugarClient context) : base(context)
        { }

      


	

	}
}