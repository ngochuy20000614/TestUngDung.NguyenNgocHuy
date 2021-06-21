using ModelEF.Model;
using ModelEF.Service;
using ModelEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung1.Areas.Admin.Common;

namespace TestUngDung1.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User

        public ActionResult Index(string keyword, int page = 1, int pageSize = 5)
        {
            if (Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "Login");
            ViewBag.search = keyword;
            var userService = new UserService();
            var result = userService.ListAllPaging(keyword, page, pageSize);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            var userService = new UserService();
            if (ModelState.IsValid)
            {
                userService.TaoMoi(user);
                TempData["result"] = "Thêm mới người dùng thành công";
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["result"] = "Thêm mới người dùng thất bại";
                return RedirectToAction("Index", "User");
            }
            return View();
        }

       
        public ActionResult Delete(int id)
        {
            var userService = new UserService();
            if (ModelState.IsValid)
            {
                if (userService.Xoa(id) == true)
                {
                    TempData["result"] = "Xóa người dùng thành công";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["result"] = "Xóa người dùng thất bại, chỉ những người dùng có trạng thái block mới được xóa";
                    return RedirectToAction("Index", "User");
                }
            }
            return View();
        }

        
        public ActionResult Edit(int id)
        {
            var userService = new UserService();
            
            return View(userService.GetUserViewModel(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {

            var userService = new UserService();
            if (ModelState.IsValid)
            {
                userService.CapNhat(user);
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["result"] = "Cập nhật người dùng thất bại";
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var userService = new UserService();
            var result = userService.GetUserViewModel(id);
            return View(result);
        }
    }
}