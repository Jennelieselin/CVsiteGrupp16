using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ApplicationUserProject
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
        [Display(Name = "Användare")]
        public string UserName { get; set; }
    }
}
