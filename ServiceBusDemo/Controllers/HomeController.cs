using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage()
        {
            string connectionString = CloudConfigurationManager.GetSetting("ServiceBusConnection");

            QueueClient Client = QueueClient.CreateFromConnectionString(connectionString, "imports");

            var message = new BrokeredMessage("Hello world " + DateTime.Now); 
            message.Properties.Add("from", "Simon");
            message.Properties.Add("platform", Request.Browser.Platform);
            
            Client.Send(message);
            
            ViewBag.Message = "Message sent.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}