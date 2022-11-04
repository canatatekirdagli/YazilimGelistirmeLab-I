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
            return View();
        }
    }
}