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
            return View();
        }
        [HttpPost]
        public ActionResult Stajİsleri(System.Web.HttpPostedFileBase yuklenecekDosya)
        {
            if (yuklenecekDosya != null)
            {
                string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar/"), dosyaYolu);
                yuklenecekDosya.SaveAs(yuklemeYeri);
            }
            return View();
        }




        public ActionResult IMEIsleri()
        {
            return View();
        }
        public ActionResult SifreDegistir()
        {
            return View();
        }
    }
}