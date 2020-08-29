using PersonelMVCUI.Models.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVCUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullanıcıInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullanıcıInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullanıcıInDb.Ad, false);
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}
