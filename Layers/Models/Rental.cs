namespace Layers.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }
        public int PricePerDay { get; set; }
        public int PricePerWeek { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime DateOfReturn { get; set; }

        public Rental(bool available, DateTime dateOfRent, DateTime dateOfReturn)
        {
            DateOfRent = dateOfRent;
            DateOfReturn = dateOfReturn;

            Model = "Husqvarna LB251S";
            Available = available || true;
            PricePerDay = 100;
            PricePerWeek = 500;
        }
    }
}