using ecooljie.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecooljie.DAL
{
   public interface IDAL<T>
    {
        /// <summary>
        /// 保存：包含新增与修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultMessage Save(T model);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="func">条件表达式： Expression<Func<Student,bool>> la =( n=>n.id > 1 && n.id <100 &&n.name !="张三" && n.matn >=60 && n.id != 50 && n.createTime != null);</param>
        /// <param name="RecordCount">总共记录数</param>
        /// <param name="orderByString">排序字符串："id asc,name desc"</param>
        /// <returns></returns>
        ResultMessage<T> GetPagingList(int PageIndex, int PageSize, Expression<Func<T, bool>> func, out long RecordCount, string orderByString);
    }
}
