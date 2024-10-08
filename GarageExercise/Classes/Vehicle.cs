﻿using GarageExercise.Interfaces;

namespace GarageExercise.Classes
{
    // Main vechile class, implementing interface IVehicle
    public class Vehicle : IVehicle
    {
        private string type;
        private string regNumber;
        private string color;
        private int wheelsNumber;

        public string Type
        {
            get => type;
            protected set => type = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string RegNumber
        {
            get => regNumber;
            protected set
            {
                if (!IsValidRegNumber(value))
                {
                    Console.WriteLine("Error: Wrong reg number format.");
                    ParkVehicle();
                }
                regNumber = value.ToUpper();
            }
        }

        public string Color
        {
            get => color;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine($"Error: Color is mandatory.");
                }
                color = value;
            }
        }

        public int WheelsNumber
        {
            get => wheelsNumber;
            protected set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: Wheels must be a positive number.");
                }
                wheelsNumber = value;
            }
        }

        protected Vehicle(string type, string regNumber, string color, int wheelsNumber)
        {
            Type = type;
            RegNumber = regNumber;
            Color = color;
            WheelsNumber = wheelsNumber;
        }

        // Validating reg number
        private bool IsValidRegNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            return true;
        }

        public virtual void IsParked() => Console.WriteLine();
        public void ParkVehicle() => Console.WriteLine();
        public void UnparkVehicle() => Console.WriteLine();
    }
}
