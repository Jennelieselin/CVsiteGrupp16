using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CvProfilRepository
    {
        private CvDbContext db = new CvDbContext();

        public List<CvProfil> GetListOfCvS(bool inloggad)
        {
            if (inloggad == true)
            {
                List<CvProfil> listOfAllaCv = db.cvs.ToList();
                if (listOfAllaCv.Count < 3)
                {
                    return listOfAllaCv;
                }
                else
                {
                    return insertRandomCv(listOfAllaCv);
                }
            }
            else
            {
                List<CvProfil> listOfAllPublic = db.cvs.Where(row => row.Privat == false).ToList();
                if (listOfAllPublic.Count < 3)
                {
                    return listOfAllPublic;
                }
                else
                {
                    return insertRandomCv(listOfAllPublic);
                }
            }
        }

        public List<CvProfil> insertRandomCv(List<CvProfil> listOfCv)
        {
            var random = new Random();
            List<CvProfil> listOfThreeRandomCV = new List<CvProfil>();
            int i1 = random.Next(listOfCv.Count);
            int i2;
            int i3;
            do
            {
                i2 = random.Next(listOfCv.Count);
                i3 = random.Next(listOfCv.Count);
            } while (i2 == i1 || i2 == i3 || i3 == i1);
            listOfThreeRandomCV.Add(listOfCv[i1]);
            listOfThreeRandomCV.Add(listOfCv[i2]);
            listOfThreeRandomCV.Add(listOfCv[i3]);
            return listOfThreeRandomCV;
        }
    }
}
