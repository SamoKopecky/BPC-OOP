using System.ServiceModel;

namespace Calculator.Service.Services
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        string Calculate(double firstNumber, double secondNumber, string operation);
    }
}