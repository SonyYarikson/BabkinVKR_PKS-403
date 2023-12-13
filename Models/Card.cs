using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Card
    {
        [Key]
        public Guid CardID { get; set; }
        [Required]
        public string CardName { get; set; }

        public Guid BoardID { get; set; }
        public Guid RowID { get; set; }
        public virtual Board Board { get; set; }
        public virtual List<Row> Rows { get; set; }
    }
}
