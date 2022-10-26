using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class UyeLoginController : Controller
    {
        // GET: UyeLogin
        public ActionResult OgrenciGiris()
        {
            return View();
        }
        public ActionResult OgretmenGiris()
        {
            return View();
        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }

    }
}