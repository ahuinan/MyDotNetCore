using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyDotNetCore.Project.Domain.Common;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Configuration;
using MyDotNetCore.Project.Infrastructure.Aop;
using MyDotNetCore.Project.Repositories.Common;

namespace MyDotNetCore.Project.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //注入数据库连接对象
            services.AddScoped<MyDotNetCoreSqlSugarClient>();

            //Aop拦截处理
            services.ConfigureDynamicProxy(config => {

                config.Interceptors.AddTyped<ErrorLogHandler>(Predicates.ForNameSpace("MyDotNetCore.*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //初始化系统配置
            Configuration.GetSection("SysConfig").Bind(new SysConfig());


        }
    }
}
