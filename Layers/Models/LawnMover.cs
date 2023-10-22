namespace Layers.Models
{
    public class Lawnmover
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }
        public int PricePerDay { get; set; }
        public int PricePerWeek { get; set; }
        public string DateOfRent { get; set; }
        public string DateOfReturn { get; set; }
    }
}