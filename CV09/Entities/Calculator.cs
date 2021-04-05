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
        private string _memory;

        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        public string Memory
        {
            get => _memory;
            set
            {
                _memory = value;
                OnPropertyChanged();
            }
        }

        public Calculator()
        {
            _state = State.Operation;
            Display = "";
            Memory = "";
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
                var result = new DataTable().Compute(Memory, null).ToString();
                if (result == "")
                {
                    result = Display;
                }

                var resultNum = double.Parse(result);
                if (resultNum % (int) resultNum != 0)
                {
                    result = $"{resultNum:F2}";
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
                Memory = "";
            }

            Memory += text;
            Display += text;
            _state = State.Number;
        }

        private void Operation(string text, char[] operations, char input)
        {
            if (text == "CE")
            {
                var operation = Memory.LastOrDefault(operations.Contains).ToString()[0];
                var lastNumber = Memory.Split(operation).Last();
                Memory = Memory.Remove(Memory.LastIndexOf(lastNumber), lastNumber.Length);
            }
            else if (input == 'C')
            {
                Memory = "";
            }
            else
            {
                switch (_state)
                {
                    case State.Number:
                        Memory += text;
                        break;
                    case State.Result:
                        Memory = $"{Display}{text}";
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