using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.Common
{
    /// <summary>
    /// 返回客户端的Message
    /// </summary>
   public class ResultMessage
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 影响的记录数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回的对象
        /// </summary>
        public object Object { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Error { get; set; } 
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
    }
    public class ResultMessage<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 影响的记录数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回的对象
        /// </summary>
        public object Object { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<T> List { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
    }
}
