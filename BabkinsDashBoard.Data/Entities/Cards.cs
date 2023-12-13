using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class Cards
    {
        [Key]
        public int CardID { get; set; }
        [Required]
        public string CardName { get; set; }
        public virtual ICollection<CardsInBoards> CardsInBoards { get; set; }
        public virtual ICollection<RowsInCards> RowsInCards { get; set; }

    }
}
