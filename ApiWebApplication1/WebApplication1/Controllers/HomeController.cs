using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        
        //IServiceProvider sp;
       //ServiceReference1.UserNamClient ser = new ServiceReference1.UserNamClient();
       
        //Service
        //UserNamClient.Service1 client = new UserNamClient.Service1();
        //UserNamClient client = new UserNamClient();
        //var client = new UserNam();

        public ActionResult Index()
        {
         //   obj.CompositeType(1);
           //int  i = client.GetData1(1);
           //var client = new UserNam();
           
            
                ViewBag.Title = "Home Page";
            // = new IServiceProvider(typeof(We)); 
            return View();
        }

        public ActionResult ViewApplication(int id, string FolderName)
        {
            //ser.
            //ser.Open();

            //ser.GetDataUsingDataContractAsync(new ServiceReference1.CompositeType());
            ////ser.A
            //ser.Close();
           
            
            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("first", "someValueOne");
            postData.Add("second", "someValueTwo");
            //return Redirect("http://www.stackoverflow.com");
            //return RedirectToAction("http://TheUrlToPostDataTo", postData);
            return View();

        }
        //static void AddCallback(object sender, AddCompletedEventArgs e)
        //{
        //    Console.WriteLine("Add Result: {0}", e.Result);
        //}

    }
}
