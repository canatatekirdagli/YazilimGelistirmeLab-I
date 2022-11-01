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
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult BilgiGoruntule()
        {
            return View();
        }
        public ActionResult StajBilgileri()
        {
            return View();
        }
        public ActionResult ImeBilgileri()
        {
            return View();
        }
        public ActionResult Stajİsleri()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/App_Data/uploads"));
            string[] fileNames = new string[files.Count()];
            for (int i = 0; i < files.Count(); i++)
            {
                fileNames[i] = files[i].Substring(files[i].IndexOf("uploads"));
            }
            TempData["files"] = fileNames;
            return View();
        }
        [HttpPost]
        public ActionResult StajIsleri(IEnumerable<HttpPostedFileBase> files, string desc)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = desc + "_" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("StajIsleri");
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