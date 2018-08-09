using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace LoggingHW.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HomeController));//Environment.MachineName);

        public HomeController()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.Info("Application started");
            Logger.Error("Error during start");
        }

        public ActionResult Index()
        {
            Logger.Info("Home/Index page opened");
            Logger.Error("Error in Home/Index");
            return View();
        }

        public ActionResult About()
        {
            Logger.Info("Home/About page opened");
            Logger.Error("Error in Home/About");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Logger.Info("Home/Contact page opened");
            Logger.Error("Error in Home/Contact");
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FakeError()
        {
            try
            {
                throw new InvalidOperationException("Exception occured");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                Logger.Info("Home/FakeError page was requested");
            }

            return View("Index");
        }
    }
}