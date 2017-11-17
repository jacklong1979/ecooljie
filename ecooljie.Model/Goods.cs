using System;

namespace ecooljie.Model
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid GoodsID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 显示关键字如：【倦后仅39.00】
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 来源【如：凤凰网、网易新闻】
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal? SourcePrice { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int? Sales { get; set; }
        /// <summary>
        /// 商家类型【0：淘宝】【1：天猫】【3：京东】
        /// </summary>
        public int? BusinessesType { get; set; }
        /// <summary>
        /// 状态【0：未发布】【1：已发布】【2：下架】【3：置顶】
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 归类如【A：今日精品推荐】【B:免费优惠活动】【C:促销活动】【D:聚划算商品】【E:20元封顶】【F:白菜价好货】【G:时尚品味】【H:9块9包邮】
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 是否包邮【0：不包邮】【1：包邮】
        /// </summary>
        public string IsFeeMailing { get; set; }
        /// <summary>
        /// 是否有优惠卷【0：没有】【1：有】
        /// </summary>
        public string IsDiscount { get; set; }
        /// <summary>
        /// 优惠卷金额
        /// </summary>
        public decimal? Discount { get; set; }
        /// <summary>
        /// 优惠卷地址_电脑
        /// </summary>
        public string PCUrl { get; set; }
        /// <summary>
        /// 优惠卷地址_手机
        /// </summary>
        public string MobileUrl { get; set; }
        /// <summary>
        /// 淘宝客长地址
        /// </summary>
        public string longUrl { get; set; }
        /// <summary>
        /// 淘宝客短地址
        /// </summary>
        public string ShortUrl { get; set; }
        /// <summary>
        /// 人气【阅读人数】
        /// </summary>
        public int? ReadCount { get; set; }
        /// <summary>
        /// 图片Url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 内容
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
        /// <summary>
        /// 商品分类
        /// </summary>
        public string Code { get; set; }

    }
}
