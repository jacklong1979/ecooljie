using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.DB.Model
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int GoodsTypeId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称:【女装】【男装】【居家】【鞋包】【特色美食】【数码产品】【护肤美装】【母婴儿童】【其他】
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
