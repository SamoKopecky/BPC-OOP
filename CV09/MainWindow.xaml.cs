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
        private readonly Calculator _calculator = new Calculator();

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = _calculator.Display;
            Memory.Text = _calculator.DisplayMemory;
            ExtraCode();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Button((sender as Button)?.Content.ToString());
            Display.Text = _calculator.Display;
            Memory.Text = _calculator.DisplayMemory;
        }


        private void ExtraCode()
        {
            EventManager.RegisterClassHandler(typeof(Button), Button.ClickEvent,
                new RoutedEventHandler(Button_Click));
        }
    }
}