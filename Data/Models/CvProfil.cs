using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CvProfil
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Namn { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Privat profil")]
        public bool Privat { get; set; }
        [Display(Name = "Bild")]
        public string ImagePath { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Username { get; set; }
    } 

}
