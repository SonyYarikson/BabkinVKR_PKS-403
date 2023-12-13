using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required]
        public Guid RoleID { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual List<Board> Board { get; set; }
    }
}
