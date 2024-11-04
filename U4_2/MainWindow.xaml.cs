using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U4_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void DelegateObj();
        public DelegateObj DelObj;

        public MainWindow()
        {
            InitializeComponent();
            DelObj = null;
        }

        private void InitButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Initialisieren");
            DelObj += Init;
        }

        private void FlushButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Spülen");
            DelObj += Flush;
        }

        private void DialysisButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Dialyse");
            DelObj += Dialysis;
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Reinigen");
            DelObj += Clean;
        }

        private void MaintainButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Wartungsmodus");
            DelObj += Maintain;
        }

        private void StandbyButton_Click(object sender, RoutedEventArgs e)
        {
            DelegateInputBox.Items.Add("Standby");
            DelObj += Standby;
        }

        private void Exec(string message)
        {
            DelegateOutputBox.Items.Add(message);
        }

        private void Init()
        {
            DelegateOutputBox.Items.Add("Init device...");
        }

        private void Flush()
        {
            DelegateOutputBox.Items.Add("Flush device...");
        }

        private void Dialysis()
        {
            DelegateOutputBox.Items.Add("Starting dialysis...");
        }

        private void Clean()
        {
            DelegateOutputBox.Items.Add("Cleaning device...");
        }

        private void Maintain()
        {
            DelegateOutputBox.Items.Add("Maintaining device...");
        }

        private void Standby()
        {
            DelegateOutputBox.Items.Add("Set device to Standby! Bye ...");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            DelObj();
            DelObj = null;
            DelegateInputBox.Items.Clear();
        }
    }
}
