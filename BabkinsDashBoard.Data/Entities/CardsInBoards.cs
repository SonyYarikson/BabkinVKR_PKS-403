using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class CardsInBoards
    {
        [Key]
        public int ListID { get; set; }
        [Required]
        public int BoardID { get; set; }
        [Required]
        public int CardID { get; set; }
        public virtual Boards Boards { get; set; }
        public virtual Cards Cards { get; set; }
    }
}
