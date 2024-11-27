namespace WaveCafe.Models
{
    public class Cofee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }
        public int CoffeeTypeId { get; set; }
        public CoffeeType CoffeeType { get; set; }



    }
}
