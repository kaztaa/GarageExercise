namespace GarageExercise.Classes
{
    // The motorcycle class
    public class Motorcycle : Vehicle
    {   // Getters
        public int CylinderVolume { get; }
        public string FuelType { get; }

        // Constructor passing all details as arbument
        public Motorcycle(string regNumber, string color, int wheelsNumber, int cylinderVolume, string fuelType)
            : base("Motorcycle", regNumber, color, wheelsNumber)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        // IsParked message
        public override void IsParked() => Console.WriteLine($"Motorcycle {RegNumber} is parked.");
    }
}