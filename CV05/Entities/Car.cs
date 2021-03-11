using System;
using System.Collections.Generic;
using System.Text;

namespace CV05.Entities
{
    abstract class Car
    {
        public int TankSize { get; protected set; }
        public int FuelInTank { get; private set; }
        public FuelType Fuel { get; set; }
        protected CarRadio CarRadio;

        protected Car(FuelType fuel)
        {
            FuelInTank = 0;
            Fuel = fuel;
            CarRadio = new CarRadio();
        }

        internal enum FuelType
        {
            Gasoline,
            Diesel
        }

        public void TankUp(FuelType fuelType, int tankAmount)
        {
            if (tankAmount + FuelInTank > TankSize)
            {
                throw new Exception("Can't tank more then the tank size!");
            }

            if (fuelType != Fuel)
            {
                throw new Exception("Can't tank with a different fuel!");
            }

            FuelInTank += tankAmount;
        }

        public void SaveRadioPrefix(int number, double frequency)
        {
            CarRadio.SavePrefix(number, frequency);
        }

        public void SetToRadioPrefix(int number) 
        {
            CarRadio.SetToPrefix(number);
        }

        public void TurnOnRadio()
        {
            CarRadio.IsRadioOn = true;
        }

        public void TurnOffRadio()
        {
            CarRadio.IsRadioOn = false;
        }
    }
}