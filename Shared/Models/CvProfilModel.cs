using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared.Models
{
    public class CvEditImg
    {
        public int Id { get; set; }
        public string CurrentPath { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }

    public class CvIndex
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Namn { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Privat sida")]
        public bool Privat { get; set; }
        [Display(Name = "Personlig bild")]
        public string ImagePath { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }
        public List<Project> ListOfProjekt { get; set; }
        public List<Utbildning> ListOfUtbildning { get; set; }
        public List<Kompetens> ListOfKompetens { get; set; }
        [Display(Name = "Erfarenheter")]
        public List<Erfarenhet> ListOfErfarenhet { get; set; }

    }

    public class CvEditInfo
    {
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string Namn { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Privat sida")]
        public bool Privat { get; set; }
    }


}
