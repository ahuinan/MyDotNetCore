using MyDotNetCore.Project.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.GenerateCode.Template
{
    public class TemplateForRepositoryInterface:BaseTemplate
    {
       

        public TemplateForRepositoryInterface(string tablename):base(tablename)
        {
           

            base.SavePath = Path.Combine(FileHelper.GetSolutionPath(), "MyDotNetCore.Project.Domain", "Repositories", $"I{base.GetHumpTableName(tablename)}Repository.cs");

            base.TemplateContent = $@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDotNetCore.Project.Infrastructure;
using MyDotNetCore.Project.Domain;
using MyDotNetCore.Project.Domain.Model;
using MyDotNetCore.Project.Infrastructure.Common;
using MyDotNetCore.Project.Domain.Message;

namespace MyDotNetCore.Project.Domain.Repositories
{{
	public interface I{GetHumpTableName(tablename)}Repository : IRepository<{tablename}>
	{{
		
	}}
}}
";
        }
    }
}
