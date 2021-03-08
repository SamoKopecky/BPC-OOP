using System;
using System.Collections.Generic;
using System.Text;

namespace CV05.Entities
{
    class CarRadio
    {
        public double TunedFrequency { get; private set; }
        public bool IsRadioOn { get; set; }
        private Dictionary<int, double> _prefixes;

        public CarRadio()
        {
            IsRadioOn = false;
            _prefixes = new Dictionary<int, double>();
        }

        public void SavePrefix(int number, double frequency)
        {
            if (_prefixes.ContainsValue(frequency))
            {
                return;
            }

            _prefixes.Add(number, frequency);
        }

        public void SetToPrefix(int number)
        {
            TunedFrequency = _prefixes[number];
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Car radio:\n");
            builder.Append($"\t\tTuned frequency: {TunedFrequency}\n");
            builder.Append($"\t\tRadio turned on: {IsRadioOn}");
            return builder.ToString();
        }
    }
}