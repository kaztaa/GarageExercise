namespace GarageExercise.Classes
{
    // The Bus class
    public class Bus : Vehicle
    {   // Getters
        public int NumberOfSeats { get; }
        public string FuelType { get; }

        // Constructor
        public Bus(string regNumber, string color, int wheelsNumber, int numberOfSeats, string fuelType)
            : base("Bus", regNumber, color, wheelsNumber)
        {
            NumberOfSeats = numberOfSeats;
            FuelType = fuelType;
        }

        // IsParked message
        public override void IsParked() => Console.WriteLine($"Bus {RegNumber} is parked.");
    }
}