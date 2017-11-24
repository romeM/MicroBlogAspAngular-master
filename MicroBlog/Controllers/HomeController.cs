using System.Web.Mvc;

namespace MicroBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return View();
        }
    }
}