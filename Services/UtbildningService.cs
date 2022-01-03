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
    public class UtbildningService
    {
        private CvDbContext db = new CvDbContext();

        public void CreateUtbildning(UtbildningModel model, int cvId)
        {
            var newUtbildning = new Utbildning()
            {
                Namn = model.Namn,
                CvId = cvId
            };
            db.utbildningar.Add(newUtbildning);
            db.SaveChanges();
        }

        public void UpdateUtbildning(Utbildning model)
        {
            var dbUtbildning = db.utbildningar.FirstOrDefault(x => x.Id == model.Id);
            dbUtbildning.Namn = model.Namn;

            db.SaveChanges();
        }
    }
}
