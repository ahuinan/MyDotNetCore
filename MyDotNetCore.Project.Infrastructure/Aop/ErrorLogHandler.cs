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
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var sbErrorMsg = new StringBuilder();
                sbErrorMsg.AppendLine($"传参:{context.Parameters.ToJson()}");
                sbErrorMsg.AppendLine($"Source:{ex.Source}");
                sbErrorMsg.AppendLine($"方法：{context.Implementation.ToString()},{context.ImplementationMethod.ToString()}");
                sbErrorMsg.AppendLine(ex.ToString());
                LogHelper.Error(sbErrorMsg.ToString());
                throw ex;
            }
        }
    }
}
