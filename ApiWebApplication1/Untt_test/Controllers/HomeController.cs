using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Untt_test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GuestList()
        {

            //IList<Guest> guestList = new List<Guest>();
            //studentList.Add(new Student() { StudentName = "Bill" });
            //studentList.Add(new Student() { StudentName = "Steve" });
            //studentList.Add(new Student() { StudentName = "Ram" });
            
            ViewData["guest"] = null;

            return View();
        }
    }
}