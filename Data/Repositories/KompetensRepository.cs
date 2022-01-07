using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class KompetensRepository
    {
        private CvDbContext db = new CvDbContext();


        public List<Kompetens> GetListOfKompetens(int cvId)
        {
            return db.Kompetens.Where(x => x.CvId == cvId).ToList();
        }
    }
}
