using MyDotNetCore.Project.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.GenerateCode.Template
{
    public class TemplateForRepository:BaseTemplate
    {
       

        public TemplateForRepository(string tablename):base(tablename)
        {
            base.SavePath = Path.Combine(FileHelper.GetSolutionPath(), "MyCode.Project.Repositories", $"{GetHumpTableName(tablename)}Repository.cs");

            base.TemplateContent = $@"using MyCode.Project.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDotNetCore.Project.Domain.Message;
using MyDotNetCore.Project.Domain.Model;
using MyDotNetCore.Project.Domain.Repositories;

namespace MyDotNetCore.Project.Repositories
{{
    public class {GetHumpTableName(tablename)}Repository: Repository<{tablename}>, I{GetHumpTableName(tablename)}Repository
    {{
        public {GetHumpTableName(tablename)}Repository(MyCodeSqlSugarClient context) : base(context)
        {{ }}

      


	

	}}
}}";
        }
    }
}
