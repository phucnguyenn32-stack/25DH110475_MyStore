using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using _25DH110475_MyStore.Models;
using _25DH110475_MyStore.Areas.Admin.Filters;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class CategoriesController : Controller
    {
        private MystoreEntities db = new MystoreEntities();

        // GET: Admin/Categories
        public ActionResult Index(string searchString, string sortOrder)
        {
            IQueryable<Category> categories = db.Categories;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                categories = categories.Where(c =>
                    c.CategoryName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(c => c.CategoryName);
                    break;

                case "name_asc":
                    categories = categories.OrderBy(c => c.CategoryName);
                    break;

                case "id_desc":
                    categories = categories.OrderByDescending(c => c.CategoryID);
                    break;

                default:
                    categories = categories.OrderBy(c => c.CategoryID);
                    break;
            }

            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;

            return View(categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category category = db.Categories.Find(id);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CategoryName")] Category category)
        {
            if (category == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                ModelState.AddModelError(
                    "CategoryName",
                    "Vui lòng nhập tên danh mục.");
            }
            else
            {
                category.CategoryName = category.CategoryName.Trim();

                bool existed = db.Categories.Any(c =>
                    c.CategoryName == category.CategoryName);

                if (existed)
                {
                    ModelState.AddModelError(
                        "CategoryName",
                        "Tên danh mục này đã tồn tại.");
                }
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Thêm danh mục thành công.";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category category = db.Categories.Find(id);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (category == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category existingCategory = db.Categories.Find(category.CategoryID);

            if (existingCategory == null)
                return HttpNotFound();

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                ModelState.AddModelError(
                    "CategoryName",
                    "Vui lòng nhập tên danh mục.");
            }
            else
            {
                category.CategoryName = category.CategoryName.Trim();

                bool existed = db.Categories.Any(c =>
                    c.CategoryID != category.CategoryID &&
                    c.CategoryName == category.CategoryName);

                if (existed)
                {
                    ModelState.AddModelError(
                        "CategoryName",
                        "Tên danh mục này đã tồn tại.");
                }
            }

            if (ModelState.IsValid)
            {
                existingCategory.CategoryName = category.CategoryName;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Cập nhật danh mục thành công.";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category category = db.Categories.Find(id);

            if (category == null)
                return HttpNotFound();

            bool hasProducts = db.Products.Any(p =>
                p.CategoryID == category.CategoryID);

            ViewBag.HasProducts = hasProducts;

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);

            if (category == null)
                return HttpNotFound();

            bool hasProducts = db.Products.Any(p =>
                p.CategoryID == category.CategoryID);

            if (hasProducts)
            {
                TempData["ErrorMessage"] =
                    "Không thể xóa danh mục đang có sản phẩm. " +
                    "Vui lòng chuyển sản phẩm sang danh mục khác trước.";

                return RedirectToAction("Index");
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Xóa danh mục thành công.";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}