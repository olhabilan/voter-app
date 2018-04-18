
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreApp.Models
{
    [Table("code")]
    public class Code
    {
        [Key]
        public int Code_id { get; set; }
        public string Code_value { get; set; }
        public int Supermarket_id { get; set; }
        public string Purchase_date { get; set; }
    }
}
