using Data.Contexts;
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
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Erfarenhet> GetListOfErfarenhet(int cvId)
        {
            return db.erfarenheter.Where(x => x.CvId == cvId).ToList();
        }
    }
}
