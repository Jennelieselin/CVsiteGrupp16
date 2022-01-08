using Data;
using Data.Models;
using Data.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class CvProfilService
    {
        private readonly HttpContext _httpcontext;
        private CvDbContext db = new CvDbContext();
        private ErfarenhetRepository erfarenhetRepository = new ErfarenhetRepository();
        private KompetensRepository kompetensRepository = new KompetensRepository();
        private ProjectRepository projectRepository = new ProjectRepository();  
        private UtbildningRepository utbildningRepository = new UtbildningRepository();

        
        public CvProfilService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public CvProfil CreateCv(string userName)
        {
            var newCv = new CvProfil()
            {
                Namn = "Okänd",
                UserName = userName,
                Privat = true
            };
            return newCv;
        }

        public CvEditInfo GetEditInfoView(int id)
        {
            CvProfil cv = db.cvs.Find(id);
            var newCvView = new CvEditInfo
            {
                Id = cv.Id,
                Namn = cv.Namn,
                Adress = cv.Adress,
                Privat = cv.Privat
            };
            return newCvView;
        }

        public void UpdateInfo(CvEditInfo newCv)
        {
            var dbCv = db.cvs.FirstOrDefault(x => x.Id == newCv.Id);
            dbCv.Namn = newCv.Namn;
            dbCv.Adress = newCv.Adress;
            dbCv.Privat = newCv.Privat;
            db.SaveChanges();
        }

        public CvEditImg GetEditImgView(int id)
        {
            CvProfil cv = db.cvs.Find(id);
            var newCvView = new CvEditImg
            {
                Id = cv.Id,
                CurrentPath = cv.ImagePath
            };
            return newCvView;
        }

        public void UpdateImg(CvEditImg model)
        {
            var currentCv = db.cvs.FirstOrDefault(x => x.Id == model.Id);
            var filename = model.Image.FileName;
            var filepath = _httpcontext.Server.MapPath("~/UploadedImages");
            model.Image.SaveAs(filepath + "/" + filename);

            currentCv.ImagePath = filename;
            db.SaveChanges();
        }

        public CvIndex GetCvIndexView(int id)
        {
            CvProfil cv = db.cvs.Find(id);
            var newCvView = new CvIndex
            {
                Id = cv.Id,
                Namn = cv.Namn,
                Adress = cv.Adress,
                Privat = cv.Privat,
                ImagePath = cv.ImagePath,
                UserName = cv.UserName,
                ListOfProjekt = projectRepository.GetListOfProjects(cv.UserName),
                ListOfErfarenhet = erfarenhetRepository.GetListOfErfarenhet(cv.Id),
                ListOfUtbildning = utbildningRepository.GetListOfUtbildning(cv.Id),
                ListOfKompetens = kompetensRepository.GetListOfKompetens(cv.Id)
            };
            return newCvView;
        }

        public IQueryable<CvProfil> GetCvWithUserName(IQueryable<string> userNames, bool inloggad)
        {
            List<CvProfil> listOfCvs = new List<CvProfil>();
            if (inloggad == true)
            {
                listOfCvs = db.cvs.ToList();
            }
            else
            {
                listOfCvs = db.cvs.Where(row => row.Privat == false).ToList();
            }
            List<CvProfil> listOfCvWithUserName = new List<CvProfil>();
            foreach (var userName in userNames)
            {
                foreach (var Cv in listOfCvs)
                {
                    if (Cv.UserName.Equals(userName))
                    {
                        listOfCvWithUserName.Add(Cv);
                    }
                }
            }
            return listOfCvWithUserName.AsQueryable();
        }
    }
}
