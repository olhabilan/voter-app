using System.ComponentModel.DataAnnotations;

namespace ScoreApp.Models
{
    public class ShopInfo
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Shop { get; set; }
        public Mark Mark { get; set; }
    }

    public class Mark
    {
        [Range(0, 6)]
        public int Price { get; set; }
        [Range(0, 6)]
        public int Service { get; set; }
        [Range(0, 6)]
        public int Overall { get; set; }
    }
}
