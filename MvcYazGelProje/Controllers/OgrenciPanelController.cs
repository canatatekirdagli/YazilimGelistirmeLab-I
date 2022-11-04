using MvcYazGelProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYazGelProje.Controllers
{
    public class OgrenciPanelController : Controller
    {
        // GET: OgrenciPanel
        Models.Entity.DBYazgelProjeEntities db = new Models.Entity.DBYazgelProjeEntities();
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult StajBilgileri()
        {
            var ogrno = (string)Session["Ogrno"];
            var stajbilgiler = db.form.Where(z => z.ogr_no == ogrno).ToList();
            return View(stajbilgiler);
        }

        public ActionResult Stajİsleri()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/StajImeDosyaları"));
            string[] fileNames = new string[files.Count()];
            for (int i = 0; i < files.Count(); i++)
            {
                fileNames[i] = files[i].Substring(files[i].IndexOf("StajImeDosyaları"));
                ViewBag.Mesaj = "DOSYA BAŞARIYLA YÜKLENDİ!";
            }
            TempData["files"] = fileNames;
            
            return View();

        }

        [HttpPost]
        public ActionResult Stajİsleri(IEnumerable<HttpPostedFileBase> imgFile)
        {
            foreach (var file in imgFile)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName =Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/StajImeDosyaları"), fileName);
                    file.SaveAs(path);
                }
            }
            
            return RedirectToAction("Stajİsleri");
        }


        public ActionResult IMEIsleri()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/StajImeDosyaları"));
            string[] fileNames = new string[files.Count()];
            for (int i = 0; i < files.Count(); i++)
            {
                fileNames[i] = files[i].Substring(files[i].IndexOf("StajImeDosyaları"));
                ViewBag.Mesaj = "DOSYA BAŞARIYLA YÜKLENDİ!";
            }
            TempData["files"] = fileNames;

            return View();

        }

        [HttpPost]
        public ActionResult IMEIsleri(IEnumerable<HttpPostedFileBase> imgFile)
        {
            foreach (var file in imgFile)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName =Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/StajImeDosyaları"), fileName);
                    file.SaveAs(path);
                    
                }
            }
            
            return RedirectToAction("IMEIsleri");
        }


       
        public ActionResult SifreDegistir()
        {
            var no = (string)Session["Ogrno"];
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