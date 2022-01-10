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

