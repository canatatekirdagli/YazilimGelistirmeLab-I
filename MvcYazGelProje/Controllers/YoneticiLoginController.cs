using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcYazGelProje.Models.Entity;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace MvcYazGelProje.Controllers
{
    public class YoneticiLoginController : Controller
    {
        // GET: YoneticiLogin
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(yonetici p)
        {
            string sifre1 = Sifrele.MD5Olustur(p.yonetici_sifre);
            var bilgiler = db.yonetici.FirstOrDefault(x => x.yonetici_kullaniciAdi==p.yonetici_kullaniciAdi && x.yonetici_sifre == sifre1);
            if (bilgiler!=null)
            {
                Session["kullaniciadi"] = bilgiler.yonetici_kullaniciAdi;
                Session["sifre"] = bilgiler.yonetici_sifre;
                Session["id"] = bilgiler.yoneticiID;
                FormsAuthentication.SetAuthCookie(bilgiler.yonetici_kullaniciAdi, false);
                return RedirectToAction("Anasayfa", "YoneticiPaneli");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı ya da Şifre";
                return View();
            }
            
            

        }
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(yonetici p)
        {
            var bilgiler = db.yonetici.FirstOrDefault(x => x.yonetici_TC == p.yonetici_TC && x.yonetici_mail == p.yonetici_mail);
            if (bilgiler != null)
            {
                string randomPassword = Membership.GeneratePassword(10, 2);
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("kocaeli.uni92@gmail.com", "uvzsvgcvycteiuhi");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.To.Add(p.yonetici_mail);
                mail.From = new MailAddress("canatatekirdagli30@gmail.com", "Kocaeli Üniversitesi Staj/İME Takip ve Değerlendirme Sistemi");
                mail.IsBodyHtml = true;
                mail.Subject = "YENİ ŞİFRENİZ";
                mail.Body += "Sisteme giriş yaparken kullanacağınız; <br/> Yeni Şifreniz: " + randomPassword + "<br/> Sisteme girdikten sonra şifrenizi değiştirmeyi unutmayın!";
                client.Send(mail);
                string sifre = Sifrele.MD5Olustur(randomPassword);
                string a = p.yonetici_TC;
                var uye = db.yonetici.Where(z => z.yonetici_TC ==a).FirstOrDefault();
                uye.yonetici_sifre = sifre;
                db.SaveChanges();
                return RedirectToAction("GirisYap");
            }
            else
            {
                ViewBag.Mesaj = "TC ya da Mail";
                return View();
            }
        }

    }
}