using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table(nameof(Board)+"s")]
    public class Board
    {
        [Key]
        public Guid BoardID { get; set; }
        public string BoardName { get; set; }
        public string Privacy { get; set; }
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}