﻿using PersonelMVCUI.Models.EntityFramework;
using PersonelMVCUI.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A ,U")]
    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Personel

        [OutputCache(Duration = 20)]
        public ActionResult Index()
        {
            var model = db.Personel.Include(x => x.Departman).ToList();

            return View(model);

        }
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }
            if (personel.Id == 0)//Ekleme
            {
                db.Personel.Add(personel);
            }
            else//Guncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;

            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)

            };
            return View("PersonelForm", model);

        }

        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if (silinecekPersonel == null)
            {
                HttpNotFound();
            }

            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }

    }
}
