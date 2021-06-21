using ModelEF.Service;
using System.Web.Mvc;
using TestUngDung1.Areas.Admin.Common;
using TestUngDung1.Areas.Admin.Data;

namespace TestUngDung1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountService();
                var result = dao.Login(model.UserName, model.Password);
                if (result == true)
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công !");
                    Session.Add(Constants.USER_SESSION, model);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công !");
                }
            }
            return View("Index");
        }
    }
}