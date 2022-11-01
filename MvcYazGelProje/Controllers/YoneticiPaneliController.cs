using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcYazGelProje.Models.Entity;

namespace MvcYazGelProje.Controllers
{
    public class YoneticiPaneliController : Controller
    {
        // GET: YoneticiPaneli
        DBYazgelProjeEntities db = new DBYazgelProjeEntities();
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult KullaniciIslemleri()
        {
            return View();
        }
        public ActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciEkle(FormCollection form)
        {
            uye uye = new uye();
            uye.uyeAd = form["uyeAd"];
            uye.uye_no = form["uye_no"];
            uye.uyeSoyad = form["uyeSoyad"];
            uye.uyeEposta = form["uyeEposta"];
            uye.uye_gsm = form["uye_gsm"];
            uye.uye_tc = form["uye_tc"];
            uye.uye_bolumAd = form["uye_bolumAd"];
            uye.uye_gorevi = "Öğrenci";
            uye.IME_durumu = false;
            db.uye.Add(uye);
            db.SaveChanges();
            return View();
        }



        public ActionResult KullaniciSil()
        {
            return View();
        }
        public ActionResult RolTanimlama()
        {
            return View();
        }
        public ActionResult OgretmenIslemleri()
        {
            return View();
        }




        public ActionResult StajGoruntuleme()
        {
            var stajbilgi = db.form.ToList();
            return View(stajbilgi);
        }
        public ActionResult StajGoruntulemeDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("Detay", bilgi);
        }






        public ActionResult StajDegerlendirme()
        {
            var stajdegerlendirme = db.form.ToList();
            return View(stajdegerlendirme);
        }
        public ActionResult StajDegerlendirmeDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("DegerlendirDetay", bilgi);
        }





        public ActionResult YoneticiIslemleri()
        {
            return View();
        }




        public ActionResult YoneticiEkleme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YoneticiEkle(FormCollection form)
        {
            yonetici yonetici = new yonetici();
            yonetici.yonetici_Ad = form["yonetici_Ad"];
            yonetici.yonetici_Soyad = form["yonetici_Soyad"];
            yonetici.yonetici_TC = form["yonetici_TC"];
            yonetici.yonetici_kullaniciAdi = form["yonetici_kullaniciAdi"];
            yonetici.yonetici_mail = form["yonetici_mail"];
            db.yonetici.Add(yonetici);
            db.SaveChanges();
            return View();
        }
        public ActionResult YoneticiSilme()
        {
            return View();
        }
        public ActionResult YoneticiGuncelleme()
        {
            return View();
        }
        public ActionResult SıfreDegistir()
        {
            return View();
        }


    }
}