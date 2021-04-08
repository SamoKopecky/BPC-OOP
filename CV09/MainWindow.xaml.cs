using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using CV09.Entities;

namespace CV09
{
    public partial class MainWindow : Window
    {
        public Calculator Calculator = new Calculator();


        public MainWindow()
        {
            InitializeComponent();
            ExtraCode();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculator.Button((sender as Button)?.Content.ToString());
        }


        private void ExtraCode()
        {
            EventManager.RegisterClassHandler(typeof(Button), Button.ClickEvent,
                new RoutedEventHandler(Button_Click));
        }
    }
}