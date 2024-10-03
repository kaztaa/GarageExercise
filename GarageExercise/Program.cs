using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GarageExercise.Classes;
using GarageExercise.Interfaces;

namespace GarageExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Initializing Garage, UI, GarageHandler and Manager
            var garage = new Garage<IVehicle>(10);
            var ui = new UI(garage);
            var garageHandler = new GarageHandler(garage, ui);
            var manager = new Manager(ui, garageHandler);
            
            manager.Start();
           
        }
    }
}
