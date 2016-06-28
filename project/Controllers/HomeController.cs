using project.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private projectContext db = new projectContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Lenguajes.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguajes lenguajes = db.Lenguajes.Find(id);
            if (lenguajes == null)
            {
                return HttpNotFound();
            }
            return View(lenguajes);
        }
    }
}