using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class OgrenciLoginController : Controller
    {
        // GET: OgrenciLogin
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap(uye p)
        {
            var bilgiler = db.uye.FirstOrDefault(x => x.uye_no == p.uye_no && x.uye_sifre == p.uye_sifre);
            if (bilgiler != null)
            {
                return RedirectToAction("Index", "OgrenciPaneli");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
    }
}