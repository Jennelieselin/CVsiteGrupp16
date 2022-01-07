using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UtbildningRepository
    {
        private CvDbContext db = new CvDbContext();

        public List<Utbildning> GetListOfUtbildning(int cvId)
        {
            return db.Utbildning.Where(x => x.CvId == cvId).ToList();
        }
    }
}
