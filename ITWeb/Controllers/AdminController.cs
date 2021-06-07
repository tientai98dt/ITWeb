using ITWebDB.Concrete;
using ITWebDB.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITWeb.Controllers
{
    public class AdminController : BaseController
    {
        ITWebEntities db = new ITWebEntities();
        // GET: Admin
        public ViewResult Index(int page = 1, string keyword = "")
        {
            int pageSize = 6;
            var model = db.Products
                .Where(x => keyword == "" || x.ProductName.Contains(keyword))
                .OrderByDescending(x => x.ProductId)
                .ToPagedList(page, pageSize);
            ViewBag.KeyWord = keyword;
            return View(model);
        }

        public ViewResult ProductAdd()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product model, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName =  Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                        _FileName);
                    file.SaveAs(_path);
                    model.ImagePath = "/UploadedFiles/"+_FileName;
                }
            }
            catch
            {

            }
            db.Products.Add(model);
            TempData["msg"] = "Đã thêm thành công sản phẩm "
                + model.ProductName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var sp = db.Products.FirstOrDefault(x => x.ProductId == id);
            db.Products.Remove(sp);
            db.SaveChanges();
            TempData["msg"] = "Đã xóa thành công";
            return RedirectToAction("Index");
        }

        public ViewResult ProductEdit(int id)
        {
            var model = db.Products
                .FirstOrDefault(x => x.ProductId == id);
            ViewBag.Categories = db.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductEdit(Product model, HttpPostedFileBase file)
        {
            var sp = db.Products
                .FirstOrDefault(x => x.ProductId == model.ProductId);
            sp.Amount = model.Amount;
            sp.CategoryId = model.CategoryId;
            sp.Price = model.Price;
            sp.ProductName = model.ProductName;
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName =Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"),
                        _FileName);
                    file.SaveAs(_path);
                    sp.ImagePath = "/UploadedFiles/" + _FileName;
                }
            }
            catch
            {

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ViewResult CategoriesList()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ViewResult CategoryAdd()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            TempData["msg"] = "Thêm thành công danh mục " + model.CategoryName;

            return RedirectToAction("CategoriesList");
        }

        public ViewResult EditCategory(int id)
        {
            var editingCategory = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            //BT: kiểm tra nếu null thì chuyển về trang not found
            return View(editingCategory);
        }

        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            var editingCategory = db.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryId);

            if (editingCategory == null)
            {
                TempData["msg"] = "Danh mục không tồn tại!";
                return RedirectToAction("CategoriesList");
            }

            editingCategory.CategoryName = model.CategoryName;
            db.SaveChanges();
            TempData["msg"] = "Chỉnh sửa thành công!";

            return RedirectToAction("CategoriesList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var delete = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (delete == null)
            {
                TempData["msg"] = "Danh mục không tồn tại!";
                return RedirectToAction("CategoriesList");
            }
            db.Categories.Remove(delete);
            db.SaveChanges();
            TempData["msg"] = "Xóa danh mục thành công!";

            return RedirectToAction("CategoriesList");
        }

        public ViewResult LienHe()
        {
            var model = db.Feedbacks.OrderByDescending(x => x.FeedbackID).ToList();
            return View(model);
        }

        public ViewResult Orders()
        {
            var model = db.Orders.OrderByDescending(x => x.OrderId).ToList();
            return View(model);
        }
    }
}