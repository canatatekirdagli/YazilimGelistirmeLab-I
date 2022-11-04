using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class KomisyonPanelController : Controller
    {
        // GET: KomisyonPanel
       DBYazgelProjeEntities db = new DBYazgelProjeEntities();
        public ActionResult Anasayfa()
        {
            return View();
        }


        public ActionResult DosyaGoruntule()
        {
            var stajbilgi = db.form.ToList();
            return View(stajbilgi);
        }
        public ActionResult Detay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("Detay", bilgi);
        }








        public ActionResult DosyaDegerlendir()
        {
            var stajdegerlendirme = db.form.ToList();
            return View(stajdegerlendirme);
        }
        public ActionResult DegerlendirDetay(int id)
        {
            var bilgi = db.form.Find(id);
            return View("DegerlendirDetay", bilgi);
        }
        public ActionResult Guncelle(form p)
        {
            var belge = db.form.Find(p.staj_id);
            belge.staj_id = p.staj_id;
            belge.stajNotu = p.stajNotu;
            belge.basvuruDurumu = p.basvuruDurumu;
            belge.sorumlu = p.sorumlu;
            db.SaveChanges();
            string ogrno = p.ogr_no;
            var a = db.uye.Where(k => p.ogr_no == ogrno).FirstOrDefault();
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("kocaeli.uni92@gmail.com", "uvzsvgcvycteiuhi");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.To.Add(a.uyeEposta);
            mail.From = new MailAddress("canatatekirdagli30@gmail.com", "Kocaeli Üniversitesi Staj/İME Takip ve Değerlendirme Sistemi");
            mail.IsBodyHtml = true;
            mail.Subject = "STAJ/IME DURUMUNUZ GÜNCELLENMİŞTİR.";
            mail.Body += p.staj_id + " NOLU STAJ/IME DURUMUNUZ GÜNCELLENMİŞTİR! SAYFANIZDAN GİRİŞ YAPARAK GÜNCELLEMEYİ GÖREBİLİRSİNİZ! </br> İYİ GÜNLER :)";
            client.Send(mail);
            return RedirectToAction("DosyaDegerlendir");

        }



        public ActionResult SifreDegistir()
        {
            var no = (string)Session["no"];
            var kullanici = db.uye.Where(z => z.uye_no == no).ToList();
            return View(kullanici); ;
        }
        public ActionResult SıfreDegistirDetay(string id)
        {
            var bilgi = db.uye.Find(id);
            return View("SıfreDegistirDetay", bilgi);
        }
        public ActionResult SıfreDegistirme(uye p)
        {

            var bilgi = db.uye.Find(p.uye_no);
            bilgi.uye_no = p.uye_no;
            string sifre = Sifrele.MD5Olustur(p.uye_sifre);
            bilgi.uye_sifre = sifre;
            db.SaveChanges();
            return View("Anasayfa", bilgi);
        }
    }
}