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


        public ActionResult StajDetay()
        {
            return View();
        }
        public ActionResult Degerlendirme()
        {
            return View();
        }
        public ActionResult DegerlendirmeDetay()
        {
            return View();
        }
        public ActionResult SifreDegistir()
        {
            return View();
        }
    }
}