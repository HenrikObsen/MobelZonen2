using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoMZ2;
using System.IO;

namespace MobelZonen2.Areas.Admin.Controllers
{
    public class AKontaktController : Controller
    {
        KontaktFac kf = new KontaktFac();

        // GET: Admin/AKontakt
        public ActionResult Index()
        {
            return View(kf.Get(1));
        }

        [HttpPost]
        public ActionResult Edit(Kontakt kontakt)
        {
            kf.Update(kontakt);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase billede)
        {
            if (billede != null)
            {
                Uploader uploader = new Uploader();
                string path = Request.PhysicalApplicationPath + "Content/Billeder/Kontakt/";

                string fil = uploader.UploadImage(billede, path, 255, true);

                Kontakt kon = kf.Get(1);
                kon.Billede = Path.GetFileName(fil);

                kf.Update(kon);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MSG = "Der er ikke valgt et billede!";
                return View("Index", kf.Get(1));
            }
            
        }
    }
}