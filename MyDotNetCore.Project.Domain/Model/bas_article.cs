using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyDotNetCore.Project.Domain.Model
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("bas_article")]
    public partial class bas_article
    {
           public bas_article(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string title {get;set;}

           /// <summary>
           /// Desc:标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string tags {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string content {get;set;}

           /// <summary>
           /// Desc:点击
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? click {get;set;}

           /// <summary>
           /// Desc:状态 1：启用 0：禁用
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

           /// <summary>
           /// Desc:来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string source {get;set;}

           /// <summary>
           /// Desc:作者
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string author {get;set;}

           /// <summary>
           /// Desc:评论次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? comment_times {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? add_time {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? update_time {get;set;}

           /// <summary>
           /// Desc:修改人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string editor {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string creater {get;set;}

    }
}
