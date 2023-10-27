namespace Layers.Models
{
    public static class Lawnmover
    {
        public class Shared
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public bool Available { get; set; }
            public int PricePerDay { get; set; }
            public int PricePerWeek { get; set; }
            public string DateOfRent { get; set; }
            public string DateOfReturn { get; set; }
            public string Type { get; set; }
        }

        public class Temp : Shared
        {
            public string BatteryEffect { get; set; }
            public string Emission { get; set; }
        }

        public class LawnmoverElectric : Shared
        {
            public string BatteryEffect { get; set; }
        }

        public class LanwmoverPetrol : Shared
        {
            public string Emission { get; set; }
        }
    }
}