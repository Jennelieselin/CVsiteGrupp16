using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Kompetens
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kompetens")]
        public string Namn { get; set; }
        [Required]
        public int CvId { get; set; }

    }
}
