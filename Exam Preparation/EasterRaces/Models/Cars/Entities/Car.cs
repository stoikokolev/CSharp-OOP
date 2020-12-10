using System;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCenitemeters;
        private const int ModelMinLength = 4;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCenitemeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCenitemeters;
        }
        
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    var msg = string.Format(ExceptionMessages.InvalidModel, value, ModelMinLength);
                    throw new ArgumentException(msg);
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    var msg = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(msg);
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => this.cubicCenitemeters;
            private set => this.cubicCenitemeters = value;
        }

        public double CalculateRacePoints(int laps) => this.cubicCenitemeters / this.horsePower * laps;
    }
}