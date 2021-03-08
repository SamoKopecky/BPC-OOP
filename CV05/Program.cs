using System;
using CV05.Entities;

namespace CV05
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new Personal(5, 50, Car.FuelType.Gasoline);
            personalCar.TankUp(Car.FuelType.Gasoline, 20);
            personalCar.TankUp(Car.FuelType.Gasoline, 10);
            personalCar.PeopleCount += 4;
            personalCar.CarRadio.SavePrefix(4, 89.5);
            personalCar.CarRadio.SetToPrefix(4);
            personalCar.CarRadio.IsRadioOn = true;
            Console.WriteLine(personalCar);
            try
            {
                personalCar.TankUp(Car.FuelType.Diesel, 20);
                //personalCar.TankUp(Car.FuelType.Gasoline, 40);
                //personalCar.PeopleCount += 2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var transportCar = new Transport(100, 75, Car.FuelType.Diesel);
            transportCar.TankUp(Car.FuelType.Diesel, 35);
            transportCar.StorageCount += 60;
            transportCar.CarRadio.SavePrefix(4, 89.5);
            transportCar.CarRadio.SavePrefix(2, 108.5);
            transportCar.CarRadio.SetToPrefix(2);
            Console.WriteLine(transportCar);

            try
            {
                //transportCar.TankUp(Car.FuelType.Gasoline, 20);
                //transportCar.TankUp(Car.FuelType.Gasoline, 100);
                transportCar.StorageCount += 50;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}