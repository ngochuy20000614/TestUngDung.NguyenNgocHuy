using System.Web.Mvc;
using TestUngDung1.Areas.Admin.Common;

namespace TestUngDung1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}