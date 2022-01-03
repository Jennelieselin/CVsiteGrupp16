using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class StartModel
    {
        public string ProjektBeskrivning { get; set; }
        public string ProjektNamn { get; set; }
        public List<CvProfil> ListOfCvs { get; set; }

    }
}
