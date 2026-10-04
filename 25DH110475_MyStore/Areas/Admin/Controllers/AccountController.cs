using _25DH110475_MyStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            using (MystoreEntities db = new MystoreEntities())
            {
                var user = db.Users.FirstOrDefault(
                    u => u.Username == username
                      && u.Password == password
                      && u.UserRole == "A"
                );

                if (user != null)
                {
                    Session["Username"] = user.Username;
                    Session["UserRole"] = user.UserRole;

                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
