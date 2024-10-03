namespace GarageExercise.Classes
{
    // The Car class
    public class Car : Vehicle
    {   // Getters
        public int CylinderVolume { get; }
        public string FuelType { get; }

        // Constructor
        public Car(string regNumber, string color, int wheelsNumber, int cylinderVolume, string fuelType)
            : base("Motorcycle", regNumber, color, wheelsNumber)
        {
            CylinderVolume = cylinderVolume;
            FuelType = fuelType;
        }

        // Parked message
        public override void IsParked() => Console.WriteLine($"Car {RegNumber} is parked.");
    }
}