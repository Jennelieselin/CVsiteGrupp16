using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        [Display(Name="Avsändare")]
        [Required]
        public string Avsändare { get; set; }
        public bool Läst { get; set; }
        [Required]
        [Display(Name="Meddelande")]
        public string Content { get; set; }
        [Display(Name ="Mottagare")]
        public string UserName { get; set; }

    }
}
