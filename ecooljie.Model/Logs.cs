using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.Model
{
    /// <summary>
    /// 浏览日志
    /// </summary>
    public class Logs
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 访问页面的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 访问页面ID
        /// </summary>
        public string PageID { get; set; }
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 访问IP
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 访问终端【安桌】【苹果】【电脑】【其他】
        /// </summary>
        public string ConnectDevice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 日志类型【0:页面浏览日志】【1:系统日志】
        /// </summary>
        public int? LogType { get; set; }

    }
}
