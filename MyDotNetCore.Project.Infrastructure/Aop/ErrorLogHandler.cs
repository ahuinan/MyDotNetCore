using AspectCore.DynamicProxy;
using MyDotNetCore.Project.Infrastructure.Extensions;
using MyDotNetCore.Project.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.Infrastructure.Aop
{
    public class ErrorLogHandler: AbstractInterceptorAttribute
    {
        private static string errMsg = $"{Environment.NewLine}----------------------------------------{Environment.NewLine}";
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var nameSpace = context.ServiceMethod.DeclaringType.Namespace;

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                LogHelper.Error(errMsg,ex);

                throw ex;
            }
        }
    }
}
