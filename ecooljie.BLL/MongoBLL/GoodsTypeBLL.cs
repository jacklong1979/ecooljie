using ecooljie.Common;
using ecooljie.DAL;
using ecooljie.DAL.MongoDAL;
using ecooljie.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ecooljie.BLL.MongoBLL
{
    public class GoodsTypeBLL
    {
       
      //  GoodsTypeDAL bll = new GoodsTypeDAL();
        IDAL<GoodsType> bll = new GoodsTypeDAL();
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResultMessage Save(GoodsType model)
        {           
           return bll.Save(model);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="func">条件表达式： Expression<Func<Student,bool>> la =( n=>n.id > 1 && n.id <100 &&n.name !="张三" && n.matn >=60 && n.id != 50 && n.createTime != null);</param>
        /// <param name="RecordCount">总共记录数</param>
        /// <param name="orderByString">排序字符串："id asc,name desc"</param>
        /// <returns></returns>

        public ResultMessage<GoodsType> GetPagingList(int PageIndex, int PageSize, Expression<Func<GoodsType, bool>> func, out long RecordCount)
        {
            try
            {
                return bll.GetPagingList(PageIndex, PageSize, func, out RecordCount,"Code asc");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
   
}
