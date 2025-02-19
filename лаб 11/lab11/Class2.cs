using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string model, int year)
        {
            Model = model;
            Year = year;
        }

        public override bool Equals(object obj)
        {
            if (obj is Car other)
            {
                return Model == other.Model && Year == other.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Model, Year);
        }
        public override string ToString()
        {
            return $"{Model} ({Year})";
        }
    }


}
