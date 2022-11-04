using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                    Session["no"] = bilgiler.uye_no;
                    return RedirectToAction("Anasayfa", "OgretmenPanel");
                }
                else if (bilgiler.uye_gorevi == "Komisyon")
                {
                    Session["AdSoyad"] = bilgiler.uyeAd + " " + bilgiler.uyeSoyad;
                    Session["no"] = bilgiler.uye_no;
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
        [HttpPost]
        public ActionResult SifremiUnuttum(uye p)
        {
            var bilgiler = db.uye.FirstOrDefault(x => x.uye_no == p.uye_no && x.uyeEposta == p.uyeEposta);
            if (bilgiler != null)
            {
                string randomPassword = Membership.GeneratePassword(10, 2);
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("kocaeli.uni92@gmail.com", "uvzsvgcvycteiuhi");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.To.Add(p.uyeEposta);
                mail.From = new MailAddress("canatatekirdagli30@gmail.com", "Kocaeli Üniversitesi Staj/İME Takip ve Değerlendirme Sistemi");
                mail.IsBodyHtml = true;
                mail.Subject = "YENİ ŞİFRENİZ";
                mail.Body += "Sisteme giriş yaparken kullanacağınız; <br/> Sicil/Öğrenci Numarası: " + p.uye_no + "<br/> Şifre: " + randomPassword + "<br/> Sisteme girdikten sonra şifrenizi değiştirmeyi unutmayın!";
                client.Send(mail);
                string sifre = Sifrele.MD5Olustur(randomPassword);
                var uye = db.uye.Find(p.uye_no);
                uye.uye_sifre = sifre;
                db.SaveChanges();
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Sicil No ya da Mail";
                return View();
            }
        }
    }
}