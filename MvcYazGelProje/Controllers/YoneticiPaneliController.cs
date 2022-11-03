using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            string randomPassword = Membership.GeneratePassword(10, 2);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("canatatekirdagli30@gmail.com", "zynwwuhkxotpokoy");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.To.Add(form["uyeEposta"]);
            mail.From = new MailAddress("canatatekirdagli30@gmail.com", "Şifre Gönderiminiz");
            mail.IsBodyHtml = true;
            mail.Subject = "Şifreniz";
            mail.Body += "Merhaba siteme hoş geldiniz :) <br/> Sisteme giriş yaparken kullanacağınız; <br/> Mail: " + form["uyeEposta"]+ "<br/> Şifre: " + randomPassword + "<br/> Sisteme girdikten sonra şifrenizi değiştirmeyi unutmayın!";

            client.Send(mail);
            string sifre = Sifrele.MD5Olustur(randomPassword);
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
            uye.uye_sifre = sifre;
            db.uye.Add(uye);
            db.SaveChanges();
            return RedirectToAction("KullaniciEkle");
        }





        public ActionResult KullaniciSil()
        {
            var kullanicisil = db.uye.ToList();
            return View(kullanicisil);
        }
        [HttpPost]
        public ActionResult KullaniciSilme(string id)
        {
            var kullanici = db.uye.Find(id);
            var kullanici1 = db.form.Where(k => k.ogr_no == id);
            var kullanici2 = db.form.Find(kullanici1);
            var kullanici3 = db.dosya.Where(k => k.ogr_no == id);
            var kullanici4 = db.dosya.Find(kullanici3);
            db.form.Remove(kullanici2);
            db.uye.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("KullaniciSil");
        }

        public ActionResult KullaniciSilDetay(string id)
        {
            var bilgi = db.uye.Find(id);
            return View("KullaniciSilDetay", bilgi);
        }
        public ActionResult KullaniciGuncelle(uye p)
        {
            var belge = db.uye.Find(p.uye_no);
            belge.uye_no = p.uye_no;
            belge.uyeAd = p.uyeAd;
            belge.uyeSoyad = p.uyeSoyad;
            belge.uye_gsm = p.uye_gsm;
            belge.uyeEposta = p.uyeEposta;
            belge.uye_bolumAd = p.uye_bolumAd;
            belge.uye_gorevi = p.uye_gorevi;
            db.SaveChanges();
            return RedirectToAction("KullaniciSil");

        }






        public ActionResult RolTanimlama()
        {
            var roltanimlama = db.uye.ToList();
            return View(roltanimlama);
        }
        public ActionResult RolTanimlamaDetay(string id)
        {
            var bilgi = db.uye.Find(id);
            return View("RolTanimlamaDetay", bilgi);
        }

        public ActionResult RolTanimlamaGuncelle(uye p)
        {
            var belge = db.uye.Find(p.uye_no);
            belge.uye_no = p.uye_no;
            belge.uye_gorevi = p.uye_gorevi;
            db.SaveChanges();
            return RedirectToAction("RolTanimlama");
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
            return View("StajGoruntulemeDetay", bilgi);
        }






        public ActionResult StajDegerlendirme()
        {
            var stajdegerlendirme = db.form.ToList();
            return View(stajdegerlendirme);
        }
        public ActionResult StajDegerlendirmeDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("StajDegerlendirmeDetay", bilgi);
        }

        public ActionResult Guncelle(form p)
        {
            var belge = db.form.Find(p.staj_id);
            belge.staj_id = p.staj_id;
            belge.stajNotu = p.stajNotu;
            belge.basvuruDurumu = p.basvuruDurumu;
            belge.sorumlu = p.sorumlu;
            db.SaveChanges();
            return RedirectToAction("StajDegerlendirme");
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
        public ActionResult YoneticiEkleme(FormCollection form)
        {
            string randomPassword = Membership.GeneratePassword(10, 2);
            string sifre = Sifrele.MD5Olustur(randomPassword);
            yonetici yonetici = new yonetici();
            yonetici.yonetici_Ad = form["yonetici_Ad"];
            yonetici.yonetici_Soyad = form["yonetici_Soyad"];
            yonetici.yonetici_TC = form["yonetici_TC"];
            yonetici.yonetici_kullaniciAdi = form["yonetici_kullaniciAdi"];
            yonetici.yonetici_mail = form["yonetici_mail"];
            yonetici.yonetici_sifre = sifre;
            db.yonetici.Add(yonetici);
            db.SaveChanges();
            return RedirectToAction("YoneticiSilme");
        }




        public ActionResult YoneticiSilme()
        {
            var kullanicisil = db.yonetici.ToList();
            return View(kullanicisil);
        }
        public ActionResult YoneticiSil(int id)
        {
            var kullanici = db.yonetici.Find(id);
            db.yonetici.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("YoneticiSilme");
        }


        public ActionResult YoneticiSilDetay(int id)
        {
            var bilgi = db.yonetici.Find(id);
            return View("YoneticiSilDetay", bilgi);
        }

        public ActionResult YoneticiGuncelle(yonetici p)
        {
            var belge = db.yonetici.Find(p.yoneticiID);
            belge.yoneticiID = p.yoneticiID;
            belge.yonetici_Ad = p.yonetici_Ad;
            belge.yonetici_Soyad = p.yonetici_Soyad;
            belge.yonetici_TC = p.yonetici_TC;
            belge.yonetici_mail = p.yonetici_mail;
            belge.yonetici_kullaniciAdi = p.yonetici_kullaniciAdi;
            db.SaveChanges();
            return RedirectToAction("YoneticiSilme");

        }



        public ActionResult SıfreDegistir()
        {
            return View();
        }



    }
}