using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class UsersProjectModel
    {
        public string Username { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }

    }

    public class DeleteUserInProjectView
    {
        [Key]
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

    }
}
