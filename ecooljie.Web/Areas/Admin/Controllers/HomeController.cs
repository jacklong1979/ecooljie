using ecooljie.BLL;
using ecooljie.BLL.MongoBLL;
using ecooljie.Common;
using ecooljie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ecooljie.Web.Areas.Admin.Controllers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

            //base.OnActionExecuting(filterContext);
            var ctx = filterContext.RequestContext.HttpContext;
            var origin = ctx.Request.Headers["Origin"];
            var allowOrigin = !string.IsNullOrWhiteSpace(origin) ? origin : "*";
            ctx.Response.AddHeader("Access-Control-Allow-Origin", allowOrigin);
            ctx.Response.AddHeader("Access-Control-Allow-Headers", "*");
            ctx.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            base.OnActionExecuting(filterContext);
        }
    }
    public class HomeController : Controller
    {
        GoodsTypeBLL gtBll = new GoodsTypeBLL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GoodsType()
        {         
            return View();
        }
        public ActionResult CustomCategory()
        {
            return View();
        }
        public ActionResult UserInfo()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Goods()
        {
            return View();
        }
        public ActionResult Logs()
        {
            return View();
        }
        #region 操作方法
        public JsonResult GetList(string name,int? page, int? rows)
        {
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"].ToString()) : 10;
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"].ToString()) : 1;
            string sort = Request["sort"] != null ? Request["sort"].ToString() : "CreateDate";
            string order = Request["order"] != null ? Request["order"].ToString() : "desc";
         
            long recordCount = 0;
            Expression<Func<GoodsType, bool>> func =null;
            if(!string.IsNullOrEmpty(name))
            {
                func = c => c.Name.Contains(name);
            }

            //  var list = gtBll.GetGoodsTypeList(pageIndex, pageSize, func, out recordCount);
            ResultMessage<GoodsType> rm = gtBll.GetPagingList(pageIndex, pageSize, func, out recordCount);
            var json = new
            {
                total = recordCount,
                rows = rm.List.ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveGoodsType()
        {
            ResultMessage rm = new ResultMessage();
            try
            {
                var name = Request.Form["name"];
                var code = Request.Form["code"];
                var remark = Request.Form["remark"];
                GoodsType model = new GoodsType();
                model.Code = code;
                model.Name = name;
                model.Remark = remark;
                rm= gtBll.Save(model);               
                return Json(rm, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                rm.Success = false;
                rm.Message = "新增失败";
                rm.Error = e.Message;
                return Json(rm, JsonRequestBehavior.AllowGet);
            }
        }
     
        #endregion
    }
}