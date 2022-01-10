using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Avsändare")]
        public string Avsändare { get; set; }
        [Display(Name ="Datum")]
        public DateTime Datum { get; set; }
        [Display(Name ="Läst")]
        public bool Läst { get; set; }
        [Display(Name ="Meddelande")]
        public string Content { get; set; }
        public string Mottagare { get; set; }


    }
}
