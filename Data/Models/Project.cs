using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }
        public string UserName { get; set; }
        public DateTime Datum { get; set; }
       
    }
}
