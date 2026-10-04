using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _25DH110475_MyStore.Models;
using System.IO;
using _25DH110475_MyStore.Models.ViewModel;
using PagedList;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private MystoreEntities db = new MystoreEntities();

        // GET: Admin/Products
        public ActionResult Index(string searchString, decimal? minPrice, decimal? maxPrice, string sortOrder, int? page)
        {
            var products = db.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p =>
                    p.ProductName.Contains(searchString) ||
                    p.ProductDecription.Contains(searchString) ||
                    p.Category.CategoryName.Contains(searchString)
                );
            }

            if (minPrice.HasValue)
            {
                products = products.Where(p => p.ProductPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.ProductPrice <= maxPrice.Value);
            }
            if (sortOrder == "name_asc")
            {
                products = products.OrderBy(p => p.ProductName);
            }
            else if (sortOrder == "name_desc")
            {
                products = products.OrderByDescending(p => p.ProductName);
            }
            else if (sortOrder == "price_asc")
            {
                products = products.OrderBy(p => p.ProductPrice);
            }
            else if (sortOrder == "price_desc")
            {
                products = products.OrderByDescending(p => p.ProductPrice);
            }
            else
            {
                products = products.OrderBy(p => p.ProductID);
            }

            int pageSize = 5;
            int pageNumber = page ?? 1;

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
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName"
            );

            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CategoryID,ProductName,ProductDecription,ProductPrice,ProductImage,UploadImg")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImg != null)
                {
                    string filename = Path.GetFileName(product.UploadImg.FileName);
                    string savePath = "~/Content/images/";

                    product.ProductImage = savePath + filename;

                    product.UploadImg.SaveAs(
                        Path.Combine(Server.MapPath(savePath), filename)
                    );
                }

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID
            );

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID
            );

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CategoryID,ProductName,ProductDecription,ProductPrice,ProductImage,UploadImg")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImg != null)
                {
                    string filename = Path.GetFileName(product.UploadImg.FileName);
                    string savePath = "~/Content/images/";

                    product.ProductImage = savePath + filename;

                    product.UploadImg.SaveAs(
                        Path.Combine(Server.MapPath(savePath), filename)
                    );
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID
            );

            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}