using System;
using System.Text;

namespace CV05.Entities
{
    class Transport : Car
    {
        public int StorageMax { get; private set; }
        private int _storageCount;

        public int StorageCount
        {
            get => _storageCount;
            set
            {
                if (value + _storageCount > StorageMax)
                {
                    throw new Exception("Can't store more storage then the storage maximum!");
                }

                _storageCount = value;
            }
        }

        public Transport(int storageMax, int tankSize, FuelType fuelType) : base(fuelType)
        {
            TankSize = tankSize;
            StorageCount = 0;
            StorageMax = storageMax;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Transport car:\n");
            builder.Append($"\tMaximum storage: {StorageMax}\n");
            builder.Append($"\tCurrent storage: {_storageCount}\n");
            builder.Append($"\tMaximum tank capacity: {TankSize}\n");
            builder.Append($"\tCurrent tank status: {FuelInTank}\n");
            builder.Append($"\t{CarRadio}");
            return builder.ToString();
        }
    }
}