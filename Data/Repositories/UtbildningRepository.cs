using Data.Contexts;
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
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Utbildning> GetListOfUtbildning(int cvId)
        {
            return db.utbildningar.Where(x => x.CvId == cvId).ToList();
        }
    }
}
