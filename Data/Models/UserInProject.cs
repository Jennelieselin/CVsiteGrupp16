using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class UserInProject
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int ProjectId { get; set; }
        [Key]
        [Column(Order = 2)]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Användare")]
        public string Username { get; set; }
    }
}
