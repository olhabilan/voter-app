using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreApp.Models.DataModels
{
    [Table("supermarket")]
    public class Supermarket
    {
        [Key]
        [Column("supermarket_id")]
        public int Id { get; set; }
        [Column("supermarket_name")]
        public string Name { get; set; }
    }
}
