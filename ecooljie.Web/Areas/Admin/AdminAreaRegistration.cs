using System.Web.Mvc;

namespace ecooljie.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional },
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },//手动增加默认主页
                new string[] { "ecooljie.Web.Areas.Admin.Controllers" }
            );
        }
    }
}