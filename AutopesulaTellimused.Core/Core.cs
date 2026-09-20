using System.Reflection.Metadata;

namespace AutopesulaTellimused.Core
{
    public enum VehicleType
    {
        Sedan, 
        SUV, 
        Van

    }

    public enum WashProgram
    {
        Express, 
        Standard,
        Premium
    }
    public class WashOrder
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }
        public WashProgram WashProgram { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }    
    }

    public static class CarWashLogic
    {
        public static decimal CalculatePrice(VehicleType vihecle, WashProgram program)
        {
            decimal basePrice = program switch
            {
                WashProgram.Express => 15.00m,
                WashProgram.Standard => 25.00m,
                WashProgram.Premium => 40.00m
            };

            decimal multiplier = vihecle switch
            {
                VehicleType.Sedan => 1.0m,
                VehicleType.SUV => 1.25m,
                VehicleType.Van => 1.5m,
                _ => 1.0m
            };

            return basePrice * multiplier;
        }

        public static int CalculateDuration(VehicleType vihecle, WashProgram program)
        {
            int baseDuration = program switch
            {
                WashProgram.Express => 15,
                WashProgram.Standard => 30,
                WashProgram.Premium => 50,
                _ => 20
            };

            int extraTime = vihecle switch
            {
                VehicleType.SUV => 2,
                VehicleType.Van => 3,
                _ => 1
            };

            return baseDuration * extraTime;
        }
    }
}
