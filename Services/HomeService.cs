//using Data.Models;
//using Data.Repositories;
//using Shared.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace Services
//{
//    public class HomeService
//    {
//        private CvProfilRepository cvProfilRepository = new CvProfilRepository();
//        private ProjectRepository projectRepository = new ProjectRepository();
//        private readonly HttpContext _httpcontext;

//        public HomeService(HttpContext httpcontext)
//        {
//            _httpcontext = httpcontext;
//        }

//        public HomeModel GetStartViewModel(bool inloggad)
//        {
//            Project latestProject = projectRepository.GetLatest();
//            if (latestProject != null)
//            {
//                var newHomeModel = new HomeModel
//                {
//                    ProjektNamn = latestProject.Namn,
//                    ProjektBeskrivning = latestProject.Beskrivning,
//                    ListOfCvs = cvProfilRepository.GetListOfCv(inloggad)
//                };
//                return newHomeModel;
//            }
//            else
//            {
//                var noProjectsHomeModel = new HomeModel
//                {
//                    ProjektNamn = null,
//                    ProjektBeskrivning = null,
//                    ListOfCvs = cvProfilRepository.GetListOfCv(inloggad)
//                };
//                return noProjectsHomeModel;
//            }
//        }
//    }
//}
