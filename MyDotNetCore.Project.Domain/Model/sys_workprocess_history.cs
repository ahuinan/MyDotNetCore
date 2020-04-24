using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyDotNetCore.Project.Domain.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sys_workprocess_history")]
    public partial class sys_workprocess_history
    {
           public sys_workprocess_history(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:路径
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string type_path {get;set;}

           /// <summary>
           /// Desc:最后修改时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime edit_time {get;set;}

           /// <summary>
           /// Desc:数字越小，优先级越高
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int priority {get;set;}

           /// <summary>
           /// Desc:类型1：函数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int func_type {get;set;}

           /// <summary>
           /// Desc:异常信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string exception_info {get;set;}

           /// <summary>
           /// Desc:备注信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string remark {get;set;}

           /// <summary>
           /// Desc:执行情况，0：等待执行 1：执行中 9：执行成功 2：执行失败
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int status {get;set;}

           /// <summary>
           /// Desc:参数信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string parameter_info {get;set;}

           /// <summary>
           /// Desc:方法名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string method_name {get;set;}

    }
}
