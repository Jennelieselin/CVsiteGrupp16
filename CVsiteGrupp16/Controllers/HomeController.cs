using Services;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService = new HomeService();

        //GET: Home/Index
        public ActionResult Index()
        {
            bool inloggad = false;
            if (User.Identity.IsAuthenticated)
            {
                inloggad = true;
            }
            var showHomeModel = homeService.GetHomeModel(inloggad);
            return View(showHomeModel);
        }
    }
}

//using Data.Contexts;
//using Data.Models;
//using Shared.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace CVsiteGrupp16.Controllers
//{
//    public class HomeController : Controller
//    {
//        public ActionResult Index()
//        {
//            StartModel mymodel = new StartModel();
//            mymodel.AllaProjekt = GetProjects();
//            return View(mymodel);
//        }

//        public List<Project> GetProjects()
//        {
//            using(var ctx = new ProjectDbContext())
//            {
//                var projects = ctx.projects.ToList();
//                return projects;
//            }

//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }
//    }
//}