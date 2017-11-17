using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.DB.Model
{
    /// <summary>
    /// 自定义商品分类
    /// </summary>
    public class CustomCategory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int CustomCategoryId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 名称【今日精品推荐】【免费优惠活动】【促销活动】【聚划算商品】【20元封顶】【白菜价好货】【时尚品味】【9块9包邮】
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
