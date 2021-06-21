using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using ModelEF.ViewModels;
using System.IO;
using Grpc.Core;
using System.Data.Entity;

namespace ModelEF.Service
{
    public class ProductService
    {
        private NguyenNgocHuyContext _context = null;
        public ProductService()
        {
            _context = new NguyenNgocHuyContext();

        }
        public List<Category> GetListCategory() => _context.Categories.ToList();

        public List<Product> GetListProduct()
        {
            return _context.Products.OrderByDescending(s=>s.Unicost).ThenBy(t=>t.Amount).ToList();
        }

        public IEnumerable<ProductViewModel> ListAllPaging(string keyword, int page, int pageSize)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.idCategory equals c.idCategory
                        select new { p, c };

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(s => s.p.Name.Contains(keyword) || s.c.Name.Contains(keyword));
            }
            var result = query.Select(x => new ProductViewModel()
            {
                idProduct = x.p.idProduct,
                NameProduct = x.p.Name,
                NameCategory = x.c.Name,
                Unicost = x.p.Unicost,
                Author = x.p.Author,
                Publisher = x.p.Publisher,
                Year = x.p.Year,
                Amount = x.p.Amount,
                Description = x.p.Description,
                Image = x.p.Image
            }).OrderBy(s => s.Amount).ThenByDescending(t => t.Unicost).ToPagedList(page, pageSize);
            return result;
        }

        
        
        

        public void TaoMoi(Product product)
        {
            var id = _context.Products.Max(x => x.idProduct);
            string phanDau = id.Substring(0, 2);
            int so = Convert.ToInt32(id.Substring(2, 2)) + 1;
            var product1 = new Product()
            {
                idProduct = so > 9 ? phanDau + so : phanDau + "0" + so,
                Name = product.Name,
                Unicost = product.Unicost,
                idCategory = product.idCategory,
                Author = product.Author,
                Publisher = product.Publisher,
                Year = product.Year,
                Description = product.Description,
                Amount = product.Amount,
                Image = product.Image
            };
            _context.Products.Add(product1);
            _context.SaveChanges();
        }

        public Product GetProductById(string id)
        {
            return _context.Products.Where(s => s.idProduct == id).SingleOrDefault();
        }

        public void Xoa(string id)
        {
            var user = GetProductById(id);
            _context.Products.Remove(user);
            _context.SaveChanges();
        }

        public void CapNhat(Product product)
        {
            Product pr = GetProductById(product.idProduct);
            pr.Name = product.Name;
            pr.idCategory = product.idCategory;
            pr.Unicost = product.Unicost;
            pr.Author = product.Author;
            pr.Publisher = product.Publisher;
            pr.Amount = product.Amount;
            pr.Description = product.Description;
            pr.Image = product.Image;
            pr.Status = product.Status;
            _context.Entry(pr).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
