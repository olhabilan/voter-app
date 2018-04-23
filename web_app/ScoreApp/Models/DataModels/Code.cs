
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreApp.Models.DataModels
{
    [Table("code")]
    public class Code
    {
        [Key]
        [Column("code_id")]
        public int Id { get; set; }
        [Column("code_value")]
        public string CodeValue { get; set; }
        [Column("supermarket_id")]
        public int SupermarketId { get; set; }
        [Column("purchase_date")]
        public string PurchaseDate { get; set; }
    }
}
