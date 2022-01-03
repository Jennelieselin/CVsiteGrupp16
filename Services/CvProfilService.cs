//using Data;
//using Data.Models;
//using Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace Services
//{
//    public class CvProfilService
//    {
//        private CvDbContext db = new CvDbContext();
//        private ErfarenhetRepository erfarenhetRepository = new ErfarenhetRepository();


//        public CvProfilService(HttpContext httpcontext)
//        {
//            _httpcontext = httpcontext;
//        }

//        public CvProfil CreateCv (string användarnamn)
//        {
//            var newCv = new CvProfil();
//            {
//                Namn = "Okänd",
//                Användarnamn = användarnamn,
//                Privat = true
//            };
//            return newCv;
//        }
//    }
//}
