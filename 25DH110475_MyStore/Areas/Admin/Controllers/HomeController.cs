
using _25DH110475_MyStore.Models;
using _25DH110475_MyStore.Areas.Admin.Filters;
using System.Linq;
using System.Web.Mvc;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MystoreEntities db = new MystoreEntities())
            {
                ViewBag.CategoryCount = db.Categories.Count();
                ViewBag.ProductCount = db.Products.Count();
                ViewBag.CustomerCount = db.Customers.Count();
                ViewBag.OrderCount = db.Orders.Count();
                ViewBag.Username = Session["Username"];
            }

            return View();
        }
    }
}
