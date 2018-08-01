using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //localhost.Service1 loc = new localhost.Service1();
        //ServiceReference1.UserNamClient client = new ServiceReference1.UserNamClient();

        public ActionResult Index()
        {
           //int i =  loc.GetData1(1);
            //client.GetData1(1);
            //ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult ViewApp(int id,string folder)
        {
            //int i =  loc.GetData1(1);
           

            return View();
        }

    }
}
