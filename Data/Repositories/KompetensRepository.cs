using Data.Contexts;
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
        private ApplicationDbContext db = new ApplicationDbContext();


        public List<Kompetens> GetListOfKompetens(int cvId)
        {
            return db.kompetens.Where(x => x.CvId == cvId).ToList();
        }
    }
}
