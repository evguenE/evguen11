using System;
using System.Web.Http;
using System.Web.Mvc;
using ApiWebApplication1.Areas.HelpPage.ModelDescriptions;
using ApiWebApplication1.Areas.HelpPage.Models;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
//using SignalRMvc.Models;
using ApiWebApplication1.Hubs;
using ApiWebApplication1.Models;


namespace ApiWebApplication1.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        //public JsonResult Apii()
        //public ActionResult Apii()
        //{
        public JsonResult Send(string message)  
        {
        
            //You need to create instance using the GlobalHost, creating a direct instance of your hub would result in to runtime exception
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        hubContext.Clients.All.addMessage(message);

        return Json(new { message = "Sent the notification." }, JsonRequestBehavior.AllowGet);


            //var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            //context.Clients.All.methodInJavascript("hello world");
            //SendMessage("Добавлен новый объект");
            var data = "test";

        //    return RedirectToAction("Index");
            //return Json(data, JsonRequestBehavior.AllowGet);            
            //return ContentResult("<script language='javascript' type='text/javascript'>alert('Data Already Exists');</script>");
        }
        
        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }

        //public ActionResult Apii()
        //{
        //    // Business logic....
        //    return Content("dfdsfsd");
        //}

        public string Get()
        {

            //var movies = new List<object>();
            return "value";
        }

        //public void Post([FromBody]string value)
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        //    hubContext.Clients.Group("TestGroup").send("TestGroup", "Called from Controller");
        //}

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}