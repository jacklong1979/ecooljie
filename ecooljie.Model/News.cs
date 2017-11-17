using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.Model
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class News
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 来源【如：凤凰网、网易新闻】
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 来源方式【0：自动采集】【1：人工采集】
        /// </summary>
        public int? SourceType { get; set; }
        /// <summary>
        /// 状态【0：未发布】【1：已发布】【2：下架】【3：置顶】
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 人气【阅读人数】
        /// </summary>
        public int? ReadCount { get; set; }
        /// <summary>
        /// 缩略图片Url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 发布人员ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 发布人员Name
        /// </summary>
        public string UserName { get; set; }

    }
}
