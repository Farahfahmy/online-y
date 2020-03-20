using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        StudentsEntities dbCon = new StudentsEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string name,string pass)
        {
            user member = dbCon.users.Where(a => a.Name == name).FirstOrDefault();

            if (member != null)
            {
               if (member.Password == pass)
                {
                    Session["name"] = member.Name;
                    return View("About");
                }
                else
                {
                    return View("index");
                }
            }

            return View("index");
        }

        public ActionResult About()
        {
            if (Session["name"]!= null)
            {
                return View();
            }
            return View("index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}