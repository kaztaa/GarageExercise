namespace GarageExercise.Classes
{
    // The airplane class
    public class Airplane : Vehicle
    {
        // Getters
        public int NumberOfEngines { get; set; }
        public int CylinderVolume { get; }
        public string FuelType { get; }

        // Constructor
        public Airplane(string regNumber, string color, int wheelsNumber, int numberOfEngines, int cylinderVolume, string fuelType)
            : base("Airplane", regNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        // IsParked message
        public override void IsParked() => Console.WriteLine($"Airplane {RegNumber} is parked.");
    }
}