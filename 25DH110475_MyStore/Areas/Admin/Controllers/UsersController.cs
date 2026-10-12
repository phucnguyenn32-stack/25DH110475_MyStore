using _25DH110475_MyStore.Areas.Admin.Filters;
using _25DH110475_MyStore.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class UsersController : Controller
    {
        private MystoreEntities db = new MystoreEntities();

        // GET: Admin/Users
        public ActionResult Index(string searchString, string sortOrder, int? page)
        {
            var users = db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = users.Where(u =>
                    u.Username.Contains(searchString) ||
                    (u.UserRole != null && u.UserRole.Contains(searchString)));
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.UsernameSort = sortOrder == "username" ? "username_desc" : "username";
            ViewBag.RoleSort = sortOrder == "role" ? "role_desc" : "role";
            ViewBag.SearchString = searchString;

            switch (sortOrder)
            {
                case "username_desc":
                    users = users.OrderByDescending(u => u.Username);
                    break;
                case "role":
                    users = users.OrderBy(u => u.UserRole);
                    break;
                case "role_desc":
                    users = users.OrderByDescending(u => u.UserRole);
                    break;
                default:
                    users = users.OrderBy(u => u.Username);
                    break;
            }

            int pageSize = 5;
            int pageNumber = page ?? 1;

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Users/Details/username
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

      
// POST: Admin/Users/Create
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(
    [Bind(Include = "Username,Password,UserRole")] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                ModelState.AddModelError("Username", "Username không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                ModelState.AddModelError("Password", "Password không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(user.UserRole))
            {
                ModelState.AddModelError("UserRole", "Quyền tài khoản không được để trống.");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (db.Users.Any(u => u.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username đã tồn tại.");
                return View(user);
            }

            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityErrors.ValidationErrors)
                    {
                        ModelState.AddModelError(
                            validationError.PropertyName,
                            validationError.ErrorMessage
                        );
                    }
                }

                return View(user);
            }
        }

        // GET: Admin/Users/Edit/username
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // POST: Admin/Users/Edit/username
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string Password, string UserRole)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                user.Password = Password;
                user.UserRole = UserRole;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Users/Delete/username
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // POST: Admin/Users/Delete/username
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            db.Users.Remove(user);
            db.SaveChanges();

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