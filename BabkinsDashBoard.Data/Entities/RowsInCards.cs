using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class RowsInCards
    {
        [Key]
        public int ListID { get; set; }
        [Required]
        public int CardID { get; set; }
        [Required]
        public int RowID { get; set; }

        public virtual Cards Cards { get; set; }
        public virtual ICollection<Rows> Rows { get; set; }
    }
}
