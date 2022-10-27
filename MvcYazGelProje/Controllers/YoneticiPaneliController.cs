using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class YoneticiPaneliController : Controller
    {
        // GET: YoneticiPaneli
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BilgiGoruntuleme()
        {
            return View();
        }
        public ActionResult KullaniciIslemleri()
        {
            return View();
        }
        public ActionResult KullaniciGuncelleme()
        {
            return View();
        }
        public ActionResult RolTanimlama()
        {
            return View();
        }
        public ActionResult StajYapanOgrenciler()
        {
            return View();
        }


    }
}