using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
  public class Vehicle
    {
        String vehicleId;
        String color;
        String brand;
        String style;
        String year;
        String power;
        String displacement;
        int capacity;
        int weight;
        String chasisNumber;
        String motorNumber;

        public string VehicleId { get => vehicleId; set => vehicleId = value; }
        public string Color { get => color; set => color = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Style { get => style; set => style = value; }
        public String Year { get => year; set => year = value; }
        public string Power { get => power; set => power = value; }
        public string Displacement { get => displacement; set => displacement = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Weight { get => weight; set => weight = value; }
        public string ChasisNumber { get => chasisNumber; set => chasisNumber = value; }
        public string MotorNumber { get => motorNumber; set => motorNumber = value; }

        public Vehicle(string vehicleId, string color, string brand, string style,String year, string power, string displacement, int capacity, int weight, string chasisNumber, string motorNumber)
        {
            this.VehicleId = vehicleId;
            this.Color = color;
            this.Brand = brand;
            this.Style = style;
            this.Year = year;
            this.Power = power;
            this.Displacement = displacement;
            this.Capacity = capacity;
            this.Weight = weight;
            this.ChasisNumber = chasisNumber;
            this.MotorNumber = motorNumber;
        }

        public Vehicle()
        {

        }
        
    }
}
