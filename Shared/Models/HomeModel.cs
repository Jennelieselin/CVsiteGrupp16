using Data.Models;
using System.Collections.Generic;


namespace Shared.Models
{
    public class HomeModel
    {
        public string ProjektBeskrivning { get; set; }
        public string ProjektNamn { get; set; }
        public List<CvProfil> ListOfCvs { get; set; }
    }
}
