using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkinsDashBoard.Data.Entities
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
