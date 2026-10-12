
using _25DH110475_MyStore.Models;
using System.Linq;
using System.Web.Mvc;
using _25DH110475_MyStore.Areas.Admin.Filters;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Username"] != null &&
                Session["UserRole"] != null &&
                Session["UserRole"].ToString() == "A")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

        // POST: Admin/Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
                return View();
            }

            using (MystoreEntities db = new MystoreEntities())
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Username == username &&
                    u.Password == password &&
                    u.UserRole == "A");

                if (user != null)
                {
                    Session.Clear();
                    Session["Username"] = user.Username;
                    Session["UserRole"] = user.UserRole;

                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }

        // GET: Admin/Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
    }
}
