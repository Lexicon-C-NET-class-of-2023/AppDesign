namespace Layers.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int RentedByAccountId { get; set; }
        public int LownMoverId { get; set; }
        public string Period { get; set; }
        public string FromDate { get; set; }
        public int HowLong { get; set; }    
        public string ToDate { get; set; }
    }
}
