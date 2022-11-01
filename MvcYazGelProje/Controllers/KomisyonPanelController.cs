using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class KomisyonPanelController : Controller
    {
        // GET: KomisyonPanel
       DBYazgelProjeEntities db = newDBYazgelProjeEntities();
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult DosyaGoruntule()
        {
            var stajbilgi = db.form.ToList();
            return View(stajbilgi);
        }
        public ActionResult Detay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("Detay", bilgi);
        }








        public ActionResult DosyaDegerlendir()
        {
            var stajdegerlendirme = db.form.ToList();
            return View(stajdegerlendirme);
        }
        public ActionResult DegerlendirDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("DegerlendirDetay", bilgi);
        }
        public ActionResult Guncelle(form p)
        {
            var bilgi = db.form.Find(p.staj_id);
            bilgi.sorumlu = p.sorumlu;
            bilgi.stajNotu = p.stajNotu;
            bilgi.basvuruDurumu = p.basvuruDurumu; 
            db.SaveChanges();
            return RedirectToAction("DosyaDegerlendir");

        }



        public ActionResult SifreDegistir()
        {
            return View();
        }
    }
}