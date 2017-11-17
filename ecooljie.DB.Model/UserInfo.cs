using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.DB.Model
{
    /// <summary>
    /// 账号信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// IM（QQ，微信，支付宝）【用来收款】
        /// </summary>
        public string IM { get; set; }
        /// <summary>
        /// 状态【0：普通人员】【1：管理员】【2：超级管理员】
        /// </summary>
        public int? Sales { get; set; }
        /// <summary>
        /// 状态【0：禁止登录】【1：可以登录】
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string IP { get; set; }

    }
}
