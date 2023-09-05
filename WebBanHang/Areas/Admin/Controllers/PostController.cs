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
    public class PostController : Controller
    {

        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 15;
            page = page ?? 1;

            IEnumerable<Posts> items = _dbConnect.Posts.OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText));
            }

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
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {

            if (ModelState.IsValid)
            {
                model.CategoryId = 3;
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Posts.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConnect.Posts.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {

            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Posts.Attach(model);
                _dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConnect.Posts.Find(id);
            if (item != null)
            {
                _dbConnect.Posts.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = _dbConnect.Posts.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                _dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _dbConnect.SaveChanges();
                return Json(new { success = true, IsActive = item.IsActive });
            }
            return Json(new { success = false });
        }




        public ActionResult DeleteAll(List<int> ids)
        {
            if (ids.Count > 0)
            {
                foreach (var id in ids)
                {
                    var obj = _dbConnect.Posts.FirstOrDefault(x => x.Id == id);
                    _dbConnect.Posts.Remove(obj);
                    _dbConnect.SaveChanges();

                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}