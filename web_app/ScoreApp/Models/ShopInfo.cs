namespace ScoreApp.Models
{
    public class ShopInfo
    {
        public string Code { get; set; }
        public string Shop { get; set; }
        public Mark Mark { get; set; }
    }

    public class Mark
    {
        public int Price { get; set; }
        public int Service { get; set; }
        public int Overall { get; set; }
    }
}
