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
        public string Namn { get; set; }
        public string Adress { get; set; }
        public string Username { get; set; }
        public string ImagePath { get; set; }
        public bool Privat { get; set; }
    }
}
