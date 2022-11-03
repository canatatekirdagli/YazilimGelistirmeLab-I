using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class OgretmenLoginController : Controller
    {
        // GET: OgretmenLogin
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
                if (bilgiler.uye_gorevi=="Öğretmen")
                {
                    Session["AdSoyad"] = bilgiler.uyeAd+" "+bilgiler.uyeSoyad;
                    return RedirectToAction("Anasayfa", "OgretmenPanel");
                }
                else if (bilgiler.uye_gorevi == "Komisyon")
                {
                    return RedirectToAction("Anasayfa", "KomisyonPanel");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz Sicil No ya da Şifre";
                    return View();
                }
               
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Sicil No ya da Şifre";
                return View();
            }
        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
    }
}