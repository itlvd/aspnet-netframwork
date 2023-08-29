using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public ActionResult Index(int ? page)
        {
            IEnumerable<Product> items = _dbContext.Products.OrderByDescending(x => x.Id);

            var pageSize = 15;
            page = page ?? 1;
            var result = items.ToPagedList(Convert.ToInt32(page), pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = page;
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}