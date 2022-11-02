﻿using System;
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
            //SmtpClient client = new SmtpClient();
            //client.Credentials = new NetworkCredential("canatatekirdagli30@gmail.com", "ŞİFRE");
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //MailMessage mail = new MailMessage();
            //mail.To.Add("canata.coc@gmail.com");
            //mail.From = new MailAddress("canatatekirdagli30@gmail.com","Şifre Gönderiminiz");
            //mail.IsBodyHtml = true;
            //mail.Subject = "Şifreniz";
            //mail.Body += "Merhaba siteme hoş geldiniz :) <br/> Sisteme giriş yaparken kullanacağınız; <br/> Mail: " + /*form["uyeEposta"]+*/ "<br/> Şifre: "+randomPassword + "<br/> Sisteme girdikten sonra şifrenizi değiştirmeyi unutmayın!";

            //    client.Send(mail);
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
            return View();
        }



        public ActionResult KullaniciSil()
        {
            var kullanicisil = db.uye.ToList();
            return View(kullanicisil);
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
            belge.uye_tc = p.uye_tc;
            belge.uyeEposta = p.uyeEposta;
            belge.uye_gsm = p.uye_gsm;
            belge.uye_bolumAd = p.uye_bolumAd;
            belge.uye_gorevi = p.uye_gorevi;
            db.SaveChanges();
            return RedirectToAction("KullaniciSil");

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
            belge.stajNotu = p.stajNotu;
            belge.sorumlu = p.sorumlu;
            belge.basvuruDurumu = p.basvuruDurumu;
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
            return View();
        }




        public ActionResult YoneticiSilme()
        {
            var kullanicisil = db.yonetici.ToList();
            return View(kullanicisil);
        }
        public ActionResult YoneticiSilDetay(int id)
        {
            var bilgi = db.yonetici.Find(id);
            return View("YoneticiSilDetay", bilgi);
        }

        public ActionResult YoneticiGuncelle(yonetici p)
        {
            var belge = db.yonetici.Find(p.yoneticiID);
            belge.yoneticiID= p.yoneticiID;
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