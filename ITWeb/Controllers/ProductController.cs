using ITWebDB.Concrete;
using ITWebDB.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITWeb.Controllers
{
    public class ProductController : Controller
    {
        ITWebEntities db = new ITWebEntities();
        // GET: Product
        public ActionResult Index(int categoryId = 0, int page=1, string keyword = "")
        {
            int pageSize = 8;
            var model = db.Products
                .Where(x => (keyword == "" || x.ProductName.Contains(keyword)) && ((categoryId == 0) || x.CategoryId == categoryId))
                .OrderByDescending(x => x.ProductId)
                .ToPagedList(page, pageSize);
            ViewBag.KeyWord = keyword;
            return View(model);
        }

        public ViewResult ProductDetails(int id)
        {
            var model = db.ProductDetails.FirstOrDefault(x => x.ProductId == id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View("NotFound");
            }
        }
        public PartialViewResult Navigation()
        {
            var model = db.Categories.ToList();
            return PartialView(model);
        }

        public ViewResult LienHe()
        {
            ViewBag.CategoryFeedback = db.CategoryFeedbacks.ToList();
            return View();
        }

        [HttpPost]

        public ActionResult LienHe(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return View("Completed");
        }
    }
}