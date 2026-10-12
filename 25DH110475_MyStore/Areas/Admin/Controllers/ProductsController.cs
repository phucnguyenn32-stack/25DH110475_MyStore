
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _25DH110475_MyStore.Models;
using _25DH110475_MyStore.Models.ViewModel;
using _25DH110475_MyStore.Areas.Admin.Filters;
using PagedList;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class ProductsController : Controller
    {
        private MystoreEntities db = new MystoreEntities();

        // GET: Admin/Products
        public ActionResult Index(
            string searchString,
            decimal? minPrice,
            decimal? maxPrice,
            string sortOrder,
            int? page)
        {
            IQueryable<Product> products =
                db.Products.Include(p => p.Category);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                products = products.Where(p =>
                    p.ProductName.Contains(searchString) ||
                    (p.ProductDecription != null &&
                     p.ProductDecription.Contains(searchString)) ||
                    (p.Category != null &&
                     p.Category.CategoryName.Contains(searchString)));
            }

            if (minPrice.HasValue)
            {
                products = products.Where(
                    p => p.ProductPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(
                    p => p.ProductPrice <= maxPrice.Value);
            }

            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(p => p.ProductName);
                    break;

                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;

                case "price_asc":
                    products = products.OrderBy(p => p.ProductPrice);
                    break;

                case "price_desc":
                    products = products.OrderByDescending(p => p.ProductPrice);
                    break;

                default:
                    products = products.OrderBy(p => p.ProductID);
                    break;
            }

            int pageSize = 5;
            int pageNumber = page ?? 1;

            ViewBag.SortOrder = sortOrder;

            var model = new SearchProductVM
            {
                SearchString = searchString,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Products = products.ToPagedList(pageNumber, pageSize)
            };

            return View(model);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName");

            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ProductID,CategoryID,ProductName,ProductDecription,ProductPrice,ProductImage,UploadImg")]
            Product product)
        {
            if (product.UploadImg == null)
            {
                ModelState.AddModelError(
                    "UploadImg",
                    "Vui lòng chọn ảnh sản phẩm.");
            }

            if (ModelState.IsValid)
            {
                string imagePath = SaveProductImage(product.UploadImg);

                if (imagePath == null)
                {
                    ModelState.AddModelError(
                        "UploadImg",
                        "Không thể lưu ảnh. Vui lòng kiểm tra lại file.");
                }
                else
                {
                    product.ProductImage = imagePath;

                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID);

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID);

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ProductID,CategoryID,ProductName,ProductDecription,ProductPrice,ProductImage,UploadImg")]
            Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(
                    db.Categories,
                    "CategoryID",
                    "CategoryName",
                    product.CategoryID);

                return View(product);
            }

            Product existingProduct = db.Products.Find(product.ProductID);

            if (existingProduct == null)
                return HttpNotFound();

            existingProduct.CategoryID = product.CategoryID;
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDecription = product.ProductDecription;
            existingProduct.ProductPrice = product.ProductPrice;

            // Không tải ảnh mới thì giữ nguyên ảnh hiện tại.
            if (product.UploadImg != null &&
                product.UploadImg.ContentLength > 0)
            {
                string imagePath = SaveProductImage(product.UploadImg);

                if (imagePath == null)
                {
                    ModelState.AddModelError(
                        "UploadImg",
                        "Không thể lưu ảnh. Vui lòng kiểm tra lại file.");

                    ViewBag.CategoryID = new SelectList(
                        db.Categories,
                        "CategoryID",
                        "CategoryName",
                        product.CategoryID);

                    return View(product);
                }

                existingProduct.ProductImage = imagePath;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Lưu ảnh vào Content/images
        private string SaveProductImage(HttpPostedFileBase upload)
        {
            if (upload == null || upload.ContentLength <= 0)
                return null;

            string extension = Path.GetExtension(upload.FileName);

            string[] allowedExtensions =
            {
                ".jpg", ".jpeg", ".png", ".gif", ".webp"
            };

            if (string.IsNullOrEmpty(extension) ||
                !allowedExtensions.Contains(extension.ToLowerInvariant()))
            {
                return null;
            }

            try
            {
                string folder = Server.MapPath("~/Content/images/");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString("N")
                    + extension.ToLowerInvariant();

                string fullPath = Path.Combine(folder, fileName);

                upload.SaveAs(fullPath);

                return "~/Content/images/" + fileName;
            }
            catch (IOException)
            {
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
