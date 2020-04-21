using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.Infrastructure.Exceptions
{
    public class BaseException : System.Exception
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public BaseException()
        {
        }

        public BaseException(string _key)
            : base(_key)
        {
            this.key = _key;
        }





    }

	/// <summary>
	/// 没有实现异常
	/// </summary>

	public class NotImplementionError : BaseException
	{
		public NotImplementionError() :base("方法没有实现异常")
		{


		}
	}

    /// <summary>
    /// 工作流异常
    /// </summary>
    public class FlowError : BaseException
    {
        public FlowError(string _key)
            : base(_key)
        {
        }
    }

    /// <summary>
    /// 没有微信支付记录异常
    /// </summary>
    public class NoWechatPayRecordError : BaseException
    {
        public NoWechatPayRecordError(string _key) : base(_key)
        { }
    }

    /// <summary>
    /// 支付成功的异常，可以避免重复的处理
    /// </summary>
    public class PayHasSuccessException : BaseException
    {
        public PayHasSuccessException(string _key) : base(_key)
        { }
    }

    /// <summary>
    /// 没有数据需要同步的异常
    /// </summary>
    public class NoDataNeedToSyncException : BaseException
    {
        public NoDataNeedToSyncException(string _key) : base(_key)
        { }
    }
}
