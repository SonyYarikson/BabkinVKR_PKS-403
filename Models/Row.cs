using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table(nameof(Row)+"s")]
    public class Row
    {
        [Key]
        public Guid RowID { get; set; }
        [Required]
        public string RowType { get; set; }
        public byte[]? RowContent { get; set; } 
        [Required]
        public Guid CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}