using Data;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KompetensService
    {
        private CvDbContext db = new CvDbContext();

        public void CreateKompetens(KompetensModel model, int cvId)
        {
            var newCompetence = new Kompetens()
            {
                Namn = model.Namn,
                CvId = cvId
            };
            db.kompetens.Add(newCompetence);
            db.SaveChanges();
        }

        public void UpdateKompetens(Kompetens model)
        {
            var dbCompetence = db.kompetens.FirstOrDefault(x => x.Id == model.Id);
            dbCompetence.Namn = model.Namn;

            db.SaveChanges();
        }
    }
}
