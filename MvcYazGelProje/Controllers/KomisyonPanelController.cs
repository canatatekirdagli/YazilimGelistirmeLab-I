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
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult DosyaGoruntule()
        {
            return View();
        }
        public ActionResult Detay()
        {
            return View();
        }

        public ActionResult DosyaDegerlendir()
        {
            return View();
        }
        public ActionResult DegerlendirDetay()
        {
            return View();
        }
        public ActionResult SifreDegistir()
        {
            return View();
        }
    }
}