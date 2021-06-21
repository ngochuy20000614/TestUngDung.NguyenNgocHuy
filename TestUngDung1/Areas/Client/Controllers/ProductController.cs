using ModelEF.Service;
using System.Web.Mvc;

namespace TestUngDung1.Areas.Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Client/Product
        public ActionResult Index(string keyword, int page = 1, int pageSize =6)
        {
            ViewBag.search = keyword;
            var proService = new ProductService();
            var result = proService.ListAllPaging(keyword, page, pageSize);
            return View(result);
        }
    }
}