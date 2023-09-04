using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        
        public ActionResult Index(int? page)
        {
            var pageSize = 15;
            page = page ?? 1;

            IEnumerable<ProductCategory> items = _dbContext.ProductCategories.OrderBy(x => x.Id);

            /*if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText));
            }*/

            var result = items.ToPagedList(Convert.ToInt32(page), pageSize);


            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = page;
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Common.Filter.FilterChar(model.Title);
                _dbContext.ProductCategories.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add");
        }
    }
}