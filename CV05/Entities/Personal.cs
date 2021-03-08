using System;
using System.Collections.Generic;
using System.Text;

namespace CV05.Entities
{
    class Personal : Car
    {
        public int PeopleMax { get; private set; }
        private int _peopleCount;

        public int PeopleCount
        {
            get => _peopleCount;
            set
            {
                if (value + _peopleCount > PeopleMax)
                {
                    throw new Exception("Can't store more people then the maximum amount of people!");
                }

                _peopleCount = value;
            }
        }

        public Personal(int peopleMax, int tankSize, FuelType fuelType) : base(fuelType, tankSize)
        {
            PeopleCount = 0;
            PeopleMax = peopleMax;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Personal car:\n");
            builder.Append($"\tMaximum people: {PeopleMax}\n");
            builder.Append($"\tCurrent people: {_peopleCount}\n");
            builder.Append($"\tMaximum tank capacity: {TankSize}\n");
            builder.Append($"\tCurrent tank status: {FuelInTank}\n");
            builder.Append($"\t{CarRadio}");
            return builder.ToString();
        }
    }
}