namespace GarageExercise.Classes
{
    // The Car class
    public class Boat : Vehicle
    {
        // Getters
        public int NumberOfEngines { get; }
        public string FuelType { get; }
        public double Length { get; }

        // Constructor
        public Boat(string regNumber, string color, int wheelsNumber, int numberOfEngines, string fuelType, double length)
            : base("Boat", regNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            FuelType = fuelType;
            Length = length;
        }

        // IsParked message
        public override void IsParked() => Console.WriteLine($"Boat {RegNumber} is parked.");
    }
}