using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoMZ2;

namespace MobelZonen2.Areas.Admin.Controllers
{
    public class AKategoriController : Controller
    {
        private KategoriFac kf = new KategoriFac();
        private SEOFac sf = new SEOFac();

        // GET: Admin/AKategori
        public ActionResult Index()
        {
            return View(kf.GetAll());
        }

        public ActionResult Delete(int id)
        {
            kf.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Kategori kat)
        {
            kf.Insert(kat);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EditKat editkat = new EditKat();
            editkat.Kategori = kf.Get(id);
            if (editkat.Kategori.SEOID > 1)
            {
                editkat.Seo = sf.Get(editkat.Kategori.SEOID);
            }
            else
            {
                SEO seo = new SEO();
                editkat.Seo = seo;
            }


            return View(editkat);
        }

        [HttpPost]
        public ActionResult Edit(Kategori kat)
        {
            kf.Update(kat);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditSEO(SEO seo, int katID)
        {
            if (seo.ID > 1)
            {
                if (ModelState.IsValid)
                {
                    sf.Update(seo);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    int id = sf.Insert(seo);
                    kf.UpdateField("SEOID", id, katID);
                }
            }


            return RedirectToAction("Index");
        }
    }
}