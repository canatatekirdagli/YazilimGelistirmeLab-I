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
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();

        [HttpGet]    //SAYFA YÜKLENDİĞİNDE ÇALIŞIR
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
        /*
        [HttpPost]   //SAYFADA TIKLANDIĞINDA ÇALIŞIR
         public ActionResult GirisYap(uye p)     // uye kısmnda hata veriyor? bir de değerler doğru mu ??
         {
             var bilgiler = db.uye.FirstOrDefault(x => x.uye_no == p.uye_no && x.uye_sifre == p.uye_sifre);
             if (bilgiler != null)
             {
                 return RedirectToAction("OgrenciPanel", "UyePanel");
             }
             else
             {
                 return RedirectToAction("OgrenciGiris");  // doğru mu ??
             }

         }

        */
    }
}