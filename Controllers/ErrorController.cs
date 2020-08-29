using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
