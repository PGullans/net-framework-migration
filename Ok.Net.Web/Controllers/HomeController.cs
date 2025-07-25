using Microsoft.AspNetCore.Mvc;

using Ok.Net.Web.Config;

namespace Ok.Net.Web.Controllers
{
    public class HomeController() : Controller
    {

        public ActionResult Index()
        {
            ViewBag.ApplicationTitle = AppKonstanten.ApplicationTitle;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}