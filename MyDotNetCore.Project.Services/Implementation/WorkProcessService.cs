using MyCode.Project.Domain.Repositories;
using MyDotNetCore.Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetCore.Project.Services.Implementation
{
    /// <summary>
    /// 基于数据库的调度表
    /// </summary>
    public class WorkProcessService: ServiceBase,IWorkProcessService
    {
        private readonly ISysWorkprocessRepository _sysWorkprocessRepository;
    }
}
