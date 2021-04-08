using System.ComponentModel;
using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CV09.Entities
{
    public class Calculator : INotifyPropertyChanged
    {
        private State _state;
        private string _display;
        private string _displayMemory;

        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        public string DisplayMemory
        {
            get => _displayMemory;
            set
            {
                _displayMemory = value;
                OnPropertyChanged();
            }
        }

        public string Memory { get; set; }

        public Calculator()
        {
            _state = State.Operation;
            Display = "";
            DisplayMemory = "";
            Memory = "0";
        }

        public void Button(string text)
        {
            if (text.Length > 2)
            {
                return;
            }

            var operations = new[] {'+', '-', '*', '/', 'C'};
            var memoryOperations = new[] {"MC", "MR", "M+", "M-", "MS"};
            var match = memoryOperations.FirstOrDefault(s => s.Equals(text));
            var input = text[0];
            if (match != null)
            {
                MemoryOperation(match);
            }
            else if (operations.Contains(input) || text == "CE")
            {
                Operation(text, operations, input);
            }
            else if (char.IsDigit(input) || input == '.')
            {
                Digit(text);
            }
            else if (input == '=')
            {
                Result();
            }
        }

        private void MemoryOperation(string match)
        {
            var intMemory = double.Parse(Memory);
            var canParse = double.TryParse(Display, out var intDisplay);
            if (match == "MC")
            {
                intMemory = 0;
            }
            else if (match == "MR")
            {
                _state = State.Number;
                intDisplay = intMemory;
                Display = $"{intDisplay}";
                DisplayMemory = $"{intDisplay}";
            }
            else if (canParse)
            {
                switch (match)
                {
                    case "M+":
                        intMemory += intDisplay;
                        break;
                    case "M-":
                        intMemory -= intDisplay;
                        break;
                    case "MS":
                        intMemory = intDisplay;
                        break;
                }
            }

            Memory = $"{intMemory}";
        }

        private void Result()
        {
            if (_state != State.Operation)
            {
                var result = new DataTable().Compute(DisplayMemory, null).ToString();
                if (result == "" || result == ".")
                {
                    return;
                }

                result = $"{double.Parse(result)}";
                Display = result;
                _state = State.Result;
            }
        }

        private void Digit(string text)
        {
            if (_state == State.Result)
            {
                Display = "";
                DisplayMemory = "";
            }

            DisplayMemory += text;
            Display += text;
            _state = State.Number;
        }

        private void Operation(string text, char[] operations, char input)
        {
            if (text == "CE")
            {
                Display = "";
                var operation = DisplayMemory.LastOrDefault(operations.Contains).ToString()[0];
                if (operation == '\0')
                {
                    DisplayMemory = "";
                }
                else
                {
                    var lastNumber = DisplayMemory.Split(operation).Last();
                    DisplayMemory = DisplayMemory.Remove(DisplayMemory.LastIndexOf(operation), lastNumber.Length + 1);
                    _state = State.Number;
                }

                return;
            }

            if (input == 'C')
            {
                DisplayMemory = "";
            }
            else if (input == '-' && DisplayMemory == "")
            {
                DisplayMemory = "-";
            }
            else
            {
                switch (_state)
                {
                    case State.Number:
                        DisplayMemory += text;
                        break;
                    case State.Result:
                        DisplayMemory = $"{Display}{text}";
                        break;
                }
            }

            Display = "";
            _state = State.Operation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}