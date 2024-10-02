using GarageExercise.Interfaces;

namespace GarageExercise
{   
    // Internal class Manager. Is used to control garage and ui.
    internal class Manager
    {
        private readonly IUI ui;
        private readonly GarageHandler garageHandler;

        public Manager(IUI ui, GarageHandler garageHandler)
        {
            this.ui = ui;
            this.garageHandler = garageHandler;
        }

        public void Start()
        {
            garageHandler.Start();
            ui.Start();
        }
    }
}