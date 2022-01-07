using Data;
using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ErfarenhetService
    {
        private CvDbContext db = new CvDbContext();

        public void CreateErfarenhet(ErfarenhetModel model, int cvId)
        {
            var newErfarenhet = new Erfarenhet()
            {
                Namn = model.Namn,
                CvId = cvId
            };
            db.Erfarenhet.Add(newErfarenhet);
            db.SaveChanges();
        }

        public void UpdateErfarenhet(Erfarenhet model)
        {
            var dbErfarenhet = db.Erfarenhet.FirstOrDefault(x => x.Id == model.Id);
            dbErfarenhet.Namn = model.Namn;

            db.SaveChanges();
        }
    }
}
