using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(nameof(UserRole) + "s")]
    public class UserRole
    {
        [Key]
        public Guid RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
