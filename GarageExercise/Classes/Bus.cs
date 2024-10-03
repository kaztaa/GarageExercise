namespace GarageExercise.Classes
{
    // The Car class
    public class Bus : Vehicle
    {   // Getters
        public int CylinderVolume { get; }
        public string FuelType { get; }

        // Constructor
        public Bus(string regNumber, string color, int wheelsNumber, int cylinderVolume, string fuelType)
            : base("Motorcycle", regNumber, color, wheelsNumber)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        // Parked message
        public override void IsParked() => Console.WriteLine($"Bus {RegNumber} is parked.");
    }
}