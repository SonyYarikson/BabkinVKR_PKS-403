using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required]
        public int RoleID { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual Boards Boards { get; set; }
    }
}
