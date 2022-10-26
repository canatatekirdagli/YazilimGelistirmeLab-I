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
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(yonetici p)
        {
            var bilgiler = db.yonetici.FirstOrDefault(x => x.yonetici_kullaniciAdi==p.yonetici_kullaniciAdi && x.yonetici_sifre == p.yonetici_sifre);
            if (bilgiler!=null)
            {
                return RedirectToAction("Index", "YoneticiPanali");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

    }
}