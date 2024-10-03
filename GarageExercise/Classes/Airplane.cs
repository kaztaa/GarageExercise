namespace GarageExercise.Classes
{
    // The airplane class
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public int CylinderVolume { get; }
        public string FuelType { get; }

        public Airplane(string regNumber, string color, int wheelsNumber, int numberOfEngines, int cylinderVolume, string fuelType)
            : base("Airplane", regNumber, color, wheelsNumber)
        {
            NumberOfEngines = numberOfEngines;
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        public override void IsParked() => Console.WriteLine($"Airplane with Register Number {RegNumber} is parked.");
    }
}