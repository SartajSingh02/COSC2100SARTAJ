// Car.cs
// Name - Sartaj Singh
// Date - 10/16/2024
// Modified - 10/16/2024
// Description - Represents a car with its attributes and methods for a car inventory application.

using System;

namespace CarInventoryApp
{
    public class Car
    {
        // Static property to track the total number of cars created
        public static int Count { get; private set; } = 0;

        // ReadOnly property for car's unique ID
        public int IdentificationNumber { get; }

        // Other car properties
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool NewStatus { get; set; }

        // Default constructor: increments Count and assigns IdentificationNumber
        public Car()
        {
            Count++;
            IdentificationNumber = Count;
        }

        // Parameterized constructor: calls the default constructor and assigns values
        public Car(string make, string model, string colour, int year, decimal price, bool newStatus) : this()
        {
            Make = make;
            Model = model;
            Colour = colour;
            Year = year;
            Price = price;
            NewStatus = newStatus;
        }

        // Override ToString() method to return car details
        public override string ToString()
        {
            return $"It Worked!";
        }
    }
}
