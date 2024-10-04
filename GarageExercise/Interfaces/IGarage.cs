namespace GarageExercise.Interfaces
{
    // Interface for Garage
    public interface IGarage<T>
    {
        void ParkVehicle(T vehicle);
        void UnparkVehicle(T vehicle);
        IEnumerable<T> Vehicles { get; }
    }
}