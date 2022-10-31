using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class OgretmenPanelController : Controller
    {
        // GET: OgretmenPanel
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult Goruntuleme()
        {
            return View();
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