using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcYazGelProje.Controllers
{
    public class OgrenciLoginController : Controller
    {
        // GET: OgrenciLogin
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(uye p)
        {
            string sifre = Sifrele.MD5Olustur(p.uye_sifre);
            var bilgiler = db.uye.FirstOrDefault(x => x.uye_no == p.uye_no && x.uye_sifre == sifre);
            if (bilgiler != null)
            {
                Session["Ogrno"] = bilgiler.uye_no;
                return RedirectToAction("Anasayfa", "OgrenciPanel");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Öğrenci No ya da Şifre";
                return View();
            }
        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
    }
}