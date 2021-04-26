using System;
using System.Windows;

namespace Calculator.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var service = new CalcServiceReference.CalcServiceClient();
            var firstNumber = Convert.ToDouble(FirstNumber.Text);
            var secondNumber = Convert.ToDouble(SecondNumber.Text);
            var result = service.Calculate(firstNumber, secondNumber, OperationBox.SelectionBoxItem.ToString());
            ResultLabel.Content = result;
        }
    }
}