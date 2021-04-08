using System.ComponentModel;
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

        public Calculator()
        {
            _state = State.Operation;
            Display = "";
            DisplayMemory = "";
        }

        public void Button(string text)
        {
            if (text.Length > 2)
            {
                return;
            }

            var operations = new[] {'+', '-', '*', '/', 'C'};
            var input = text[0];
            if (operations.Contains(input) || text == "CE")
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

        private void Result()
        {
            if (_state != State.Operation)
            {
                var result = new DataTable().Compute(DisplayMemory, null).ToString();
                if (result == "")
                {
                    result = Display;
                }

                var resultNum = double.Parse(result);
                if (resultNum % (int) resultNum != 0)
                {
                    result = $"{resultNum:F4}";
                }
                else
                {
                    result = $"{(int) resultNum}";
                }

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
                var operation = DisplayMemory.LastOrDefault(operations.Contains).ToString()[0];
                var lastNumber = DisplayMemory.Split(operation).Last();
                DisplayMemory = DisplayMemory.Remove(DisplayMemory.LastIndexOf(lastNumber), lastNumber.Length);
            }
            else if (input == 'C')
            {
                DisplayMemory = "";
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