using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoMZ2;

namespace MobelZonen2.Controllers
{
    public class HomeController : Controller
    {

        KontaktFac kf = new KontaktFac();


        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }

        public ActionResult MailForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MailForm(string Email, string Emne, string Besked)
        {
            MailFac mf = new MailFac("smtp.gmail.com", "webitgrenaa@gmail.com", "webitgrenaa@gmail.com", "Obsengud78", 587);

            mf.Send(Emne, Email + "<br/>" + Besked, "hto@djes.dk");

            ViewBag.MSG = "Din besked er sendt!";

            return View();

        }


    }
}