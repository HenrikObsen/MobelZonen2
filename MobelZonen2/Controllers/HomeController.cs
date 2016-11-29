using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using RepoMZ2;
using RepoMZ2.Factories;

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
        public ActionResult Login(string email, string adgangskode)
        {
            BrugerFac bf = new BrugerFac();
            Bruger bruger = bf.Login(email.Trim(), Crypto.Hash(adgangskode.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                Response.Redirect("/Admin/Default/Index/");
            }

            return Redirect("/Home/Login/");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
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

