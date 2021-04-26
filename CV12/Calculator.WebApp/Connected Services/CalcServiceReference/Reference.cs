﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calculator.WebApp.CalcServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CalcServiceReference.ICalcService")]
    public interface ICalcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcService/Calculate", ReplyAction="http://tempuri.org/ICalcService/CalculateResponse")]
        string Calculate(double firstNumber, double secondNumber, string operation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcService/Calculate", ReplyAction="http://tempuri.org/ICalcService/CalculateResponse")]
        System.Threading.Tasks.Task<string> CalculateAsync(double firstNumber, double secondNumber, string operation);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalcServiceChannel : Calculator.WebApp.CalcServiceReference.ICalcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalcServiceClient : System.ServiceModel.ClientBase<Calculator.WebApp.CalcServiceReference.ICalcService>, Calculator.WebApp.CalcServiceReference.ICalcService {
        
        public CalcServiceClient() {
        }
        
        public CalcServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalcServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Calculate(double firstNumber, double secondNumber, string operation) {
            return base.Channel.Calculate(firstNumber, secondNumber, operation);
        }
        
        public System.Threading.Tasks.Task<string> CalculateAsync(double firstNumber, double secondNumber, string operation) {
            return base.Channel.CalculateAsync(firstNumber, secondNumber, operation);
        }
    }
}
