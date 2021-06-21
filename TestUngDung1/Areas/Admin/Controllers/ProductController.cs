using ModelEF.Model;
using ModelEF.Service;
using ModelEF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung1.Areas.Admin.Common;

namespace TestUngDung1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
       
        // GET: Admin/Product
        public ActionResult Index(string keyword, int page = 1, int pageSize = 4)
        {
            if (Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "Login");
           
            ViewBag.search = keyword;
            var proService = new ProductService();
            var result = proService.ListAllPaging(keyword, page, pageSize);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(result);
        }

        
        public ActionResult Create()
        {
            var proService = new ProductService();
            ViewBag.IdCategory = new SelectList(proService.GetListCategory(), "IdCategory", "Name");
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                string extension = Path.GetExtension(product.ImageUpload.FileName);
                filename = filename + extension;
                product.Image = "~/Asset/Admin/Image/Product/" + filename;
                product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Asset/Admin/Image/Product/"), filename));
                var proService = new ProductService();
                proService.TaoMoi(product);
                TempData["result"] = "Thêm mới sách thành công";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        
        public ActionResult Delete(string id)
        {
            var proService = new ProductService();
            if (ModelState.IsValid)
            {
                proService.Xoa(id);
                TempData["result"] = "Xóa sách thành công";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["result"] = "Xóa sách dùng thất bại";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

       
        public ActionResult Edit(string id)
        {
            var proService = new ProductService();
            ViewBag.IdCategory = new SelectList(proService.GetListCategory(), "IdCategory", "Name");
            return View(proService.GetProductById(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if(product.Image != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    string extension = Path.GetExtension(product.ImageUpload.FileName);
                    filename = filename + extension;
                    product.Image = "~/Asset/Admin/Image/Product/" + filename;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Asset/Admin/Image/Product/"), filename));
                    var proService = new ProductService();
                    proService.CapNhat(product);
                    TempData["result"] = "Cập nhật sách thành công";
                    
                    return RedirectToAction("Index", "Product");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        public ActionResult Details(string id)
        {
            var productService = new ProductService();
            var result = productService.GetProductById(id);
            return View(result);
        }


    }
}