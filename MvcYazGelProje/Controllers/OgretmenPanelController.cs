using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcYazGelProje.Models.Entity;

namespace MvcYazGelProje.Controllers
{
    public class OgretmenPanelController : Controller
    {
        // GET: OgretmenPanel
        DBYazgelProjeEntities3 db = new DBYazgelProjeEntities3();
        public ActionResult AnaSayfa()
        {
            return View();
        }




        public ActionResult Goruntuleme()
        {
            var stajbilgi = db.form.ToList();
            return View(stajbilgi);
        }


        public ActionResult StajDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("StajDetay", bilgi);
        }




        public ActionResult Degerlendirme()
        {
            var stajdegerlendirme = db.form.ToList();
            return View(stajdegerlendirme);
            
        }
        public ActionResult DegerlendirmeDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("DegerlendirmeDetay", bilgi);
        }


        public ActionResult Guncelle(form p)
        {
            var bilgi = db.form.Find(p.staj_id);
            bilgi.stajNotu = p.stajNotu;
            bilgi.basvuruDurumu = p.basvuruDurumu;
            db.SaveChanges();
            return RedirectToAction("Degerlendirme"); 

        }



        public ActionResult SifreDegistir()
        {
            return View();
        }
    }
}