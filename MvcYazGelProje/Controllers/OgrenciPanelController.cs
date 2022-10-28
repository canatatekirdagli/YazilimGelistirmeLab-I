using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class OgrenciPanelController : Controller
    {
        // GET: OgrenciPanel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BilgiGoruntule()
        {
            return View();
        }
        public ActionResult Stajİsleri()
        {
            return View();
        }
        public ActionResult IMEIsleri()
        {
            return View();
        }
        public ActionResult SurecTakip()
        {
            return View();
        }
    }
}