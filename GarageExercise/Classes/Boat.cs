namespace GarageExercise.Classes
{
    public class Boat : Vehicle
    {
        public int NumberOfEngines { get; }
        public string FuelType { get; }
        public double Length { get; }

        public Boat(string regNumber, string color, int wheelsNumber, int numberOfEngines, string fuelType, double length)
            : base("Boat", regNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            FuelType = fuelType;
            Length = length;
        }

        public override void IsParked() => Console.WriteLine($"Boat {RegNumber} is parked.");
    }
}