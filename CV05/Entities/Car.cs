using System;
using System.Collections.Generic;
using System.Text;

namespace CV05.Entities
{
    class Car
    {
        public int TankSize { get; protected set; }
        public int FuelInTank { get; private set; }
        public FuelType Fuel { get; set; }
        public CarRadio CarRadio { get; set; }

        public Car(FuelType fuel)
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
    }
}