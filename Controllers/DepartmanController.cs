using PersonelMVCUI.Models.EntityFramework;
using PersonelMVCUI.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    //[Route("[controller]/index")]
    [Authorize]
    [Authorize(Roles = "A ,U")]
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Departman
        [OutputCache(Duration = 20)]
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm");
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.Ad + "başarıyla eklendi";
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if (guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }

                guncellenecekDepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + "başarıyla güncellendi";
            }
            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if (silinecekDepartman == null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
