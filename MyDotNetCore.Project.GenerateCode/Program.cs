using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetCore.Project.GenerateCode.Template;
using MyDotNetCore.Project.Infrastructure.Common;
using MyDotNetCore.Project.Infrastructure.Helper;
using MyDotNetCore.Project.Repositories.Common;
using SqlSugar;
using System;
using System.IO;

namespace MyDotNetCore.Project.GenerateCode
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.InitMyDotNetCore();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var db = serviceProvider.GetService<ISqlSugarClient>())
            {

                Console.WriteLine(db.GetHashCode());

                var tables = db.DbMaintenance.GetTableInfoList();

                var solutionPath = FileHelper.GetSolutionPath();

                Console.WriteLine($"当前解决方案所在目录：{solutionPath}");

                //生成所有实体
                db.DbFirst.IsCreateAttribute(true).CreateClassFile(Path.Combine(solutionPath, "MyDotNetCore.Project.Domain", "Model"), "MyDotNetCore.Project.Domain.Model");

                foreach (var table in tables)
                {

                    Console.WriteLine(table.Name);

                    //创建仓储接口
                    var templateForRepositoryInterface = new TemplateForRepositoryInterface(table.Name);

                    templateForRepositoryInterface.CreateFile();

                    //创建仓储实现类
                    var templateForRepository = new TemplateForRepository(table.Name);

                    templateForRepository.CreateFile();
                }

                Console.WriteLine("代码生成成功");

            }
            
            
        }


    }
}
