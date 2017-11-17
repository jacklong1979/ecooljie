using ecooljie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecooljie.Common;
using System.Linq.Expressions;
using ecooljie.DB.MongoDB;

namespace ecooljie.DAL.MongoDAL
{
    public class GoodsTypeDAL : IDAL<GoodsType>
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResultMessage Save(GoodsType model)
        {
            ResultMessage rm = new ResultMessage();
            try
            {
                MongoDBHelper.InsertOne<GoodsType>(model);
                rm.Success = true;
                rm.Message = "保存成功！";
            }
            catch (Exception e)
            {
                rm.Success = false;
                rm.Message = "保存失败！";
                rm.Error = e.Message;
                rm.Exception = e;
            }
            return rm;
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

        public ResultMessage<GoodsType> GetPagingList(int PageIndex, int PageSize, Expression<Func<GoodsType, bool>> func, out long RecordCount, string orderByString)
        {
            ResultMessage<GoodsType> rm = new ResultMessage<GoodsType>();
            RecordCount = 0;
            try
            {
                var list= MongoDBHelper.QueryList<GoodsType>(PageIndex, PageSize, func, out RecordCount, orderByString);
                rm.Success = true;               
                rm.List = list;               
                rm.Count = Convert.ToInt32(RecordCount);
            }
            catch (Exception e)
            {
                rm.Success = false;
                rm.Message = "获取记录失败！";
                rm.Error = e.Message;
                rm.Exception = e;
                rm.Count =Convert.ToInt32(RecordCount);
            }
            return rm;
        }
    }
}
