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
            return View(kf.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Kategori kat)
        {
            kf.Update(kat);
            return RedirectToAction("Index");
        }
    }
}