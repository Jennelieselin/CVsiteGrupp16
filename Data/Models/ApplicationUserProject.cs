using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public  class ApplicationUserProject
    {
       [Key]
        [Column(Order = 1)]
        [Required]
       public int ProjectId { get; set; }
        [Key]
        [Column(Order = 2)]
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Username{ get; set; }


    }
}
