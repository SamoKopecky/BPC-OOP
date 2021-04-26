using System.Data;

namespace Calculator.Service.Services
{
    public class CalcService : ICalcService
    {
        public string Calculate(double firstNumber, double secondNumber, string operation)
        {
            var toCalculate = $"{firstNumber}{operation}{secondNumber}";
            return new DataTable().Compute(toCalculate, null).ToString();
        }
    }
}