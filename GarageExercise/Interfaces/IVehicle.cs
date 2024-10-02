namespace GarageExercise.Interfaces
{
    // Interface for class Vechicle 
    public interface IVehicle
    {
        string Type { get; }
        string RegNumber { get; }
        string Color { get; }
        int WheelsNumber { get; }

        void IsParked();
        void ParkVehicle();
        void UnparkVehicle();
    }
}
