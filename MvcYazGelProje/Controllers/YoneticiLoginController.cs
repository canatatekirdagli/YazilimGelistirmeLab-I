using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcYazGelProje.Models.Entity;
using System.Web.Security;

namespace MvcYazGelProje.Controllers
{
    public class YoneticiLoginController : Controller
    {
        // GET: YoneticiLogin
        Models.Entity.DBYazgelProjeEntities3 db = new Models.Entity.DBYazgelProjeEntities3();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(yonetici p)
        {
            var bilgiler = db.yonetici.FirstOrDefault(x => x.yonetici_kullaniciAdi==p.yonetici_kullaniciAdi && x.yonetici_sifre == p.yonetici_sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.yonetici_kullaniciAdi, false);
                return RedirectToAction("Anasayfa", "YoneticiPaneli");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı ya da Şifre";
                return View();
            }
            
        }

    }
}