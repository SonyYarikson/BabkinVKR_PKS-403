using System.ComponentModel.DataAnnotations;

namespace BabkinsDashBoard.Data.Entities
{
    public class Rows
    {
        [Key]
        public int RowID { get; set; }
        [Required]
        public string RowType { get; set; }
        public string RowContent { get; set; }
        public ICollection<RowsInCards> RowsInCards { get; set; }
    }
}
