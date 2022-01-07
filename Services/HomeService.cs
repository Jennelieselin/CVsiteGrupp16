using Data.Models;
using Data.Repositories;
using Shared.Models;
using System.Web;

namespace Services
{
    public class HomeService
    {
        private CvProfilRepository cvRepository = new CvProfilRepository();
        private ProjectRepository projectRepository = new ProjectRepository();

        public HomeModel GetHomeModel(bool inloggad)
        {
            Project latestProject = projectRepository.GetLatest();
            if (latestProject != null)
            {
                var newHomeModel = new HomeModel
                {
                    ProjektNamn = latestProject.Namn,
                    ProjektBeskrivning = latestProject.Beskrivning,
                    ListOfCvs = cvRepository.GetListOfCvS(inloggad)
                };
                return newHomeModel;
            }
            else
            {
                var noProjectsHomeModel = new HomeModel
                {
                    ProjektNamn = null,
                    ProjektBeskrivning = null,
                    ListOfCvs = cvRepository.GetListOfCvS(inloggad)
                };
                return noProjectsHomeModel;
            }
        }
    }
}
