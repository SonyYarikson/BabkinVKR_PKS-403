using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class Boards
    {
        [Key]
        public int BoardID { get; set; }
        [Required]
        public string BoardName { get; set; }
        [Required]
        public string Privacy { get; set; }
        [Required]
        public string Creator { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<CardsInBoards> CardsInBoards { get; set; }
    }
}
