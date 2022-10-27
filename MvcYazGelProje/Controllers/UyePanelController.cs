using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class UyePanelController : Controller
    {
        // GET: UyePanel
        public ActionResult OgrenciPanel()
        {
            return View();
        }

        public ActionResult OgretmenPanel()
        {
            return View();
        }

    }
}