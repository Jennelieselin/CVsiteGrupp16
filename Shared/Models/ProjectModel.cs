using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ProjectModel
    {
        [Key]
        [Display(Name ="Projekt")]
        public string Namn { get; set; }

        [Display(Name ="Beskrivning")]
        public string Beskrivning { get; set; }

        [Display(Name ="Datum")]
        public DateTime Datum { get; set; }

    }
}
