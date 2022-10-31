﻿using MvcYazGelProje.Models.Entity;
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
        Models.Entity.DBYazgelProjeEntities1 db = new Models.Entity.DBYazgelProjeEntities1();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(uye p)
        {
            var bilgiler = db.uye.FirstOrDefault(x => x.uye_no == p.uye_no && x.uye_sifre == p.uye_sifre);
            if (bilgiler != null)
            {

                return RedirectToAction("Anasayfa", "OgretmenPaneli");
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