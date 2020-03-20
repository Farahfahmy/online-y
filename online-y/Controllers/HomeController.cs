using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_y.Controllers
{
    public class HomeController : Controller
    {
        LoginEntities dbCon = new LoginEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string name, string pass)
        {
            user person = dbCon.users.Where(a => a.Name == name).FirstOrDefault();

            if (person != null)
            {
                if (person.Password == pass)
                {
                    Session["name"] = person.Name;
                    if (person.userTyper == 1)
                    {
                        Session["type"] = "student";
                        return RedirectToAction("Studentpage");
                    }
                    if (person.userTyper == 2)
                    {
                        Session["type"] = "teacher";
                        return RedirectToAction("Istructorpage");
                    }
                }
                else
                {
                    return View("index");
                }
            }
            return View("index");
        }

        public ActionResult LogOut()
        {
            Session["type"] = null;
            Session["name"] = null;
            return View("index");

        }
        public ActionResult Learnmore()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult StudentR()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult InstructorR()
        {
            return View();
        }

        public ActionResult Studentpage()
        {
            if (Session["type"] != null && Session["type"].ToString() == "student")
            {
                return View();
            }
            return View("Index");
        }
        public ActionResult Istructorpage()
        {
            if (Session["type"] != null && Session["type"].ToString() == "teacher")
            {
                return View();
            }
            return View("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}