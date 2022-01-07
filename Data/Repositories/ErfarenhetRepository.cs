using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ErfarenhetRepository
    {
        private CvDbContext db = new CvDbContext();

        public List<Erfarenhet> GetListOfErfarenhet (int cvId)
        {
            return db.Erfarenhet.Where(x => x.CvId == cvId).ToList();
        }
    }
}
