using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uebung1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // --------------------------------------------------------------------------------------------------------------
        // Notifications
        // --------------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // --------------------------------------------------------------------------------------------------------------
        // End Notifications
        // --------------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------------
        // Attributes
        // --------------------------------------------------------------------------------------------------------------
        private ObservableCollection<Client> clients = new ObservableCollection<Client>();
        public ObservableCollection<Client> Clients 
        {
            get { return clients; } 
            set 
            { 
                clients = value; 
                OnPropertyChanged(nameof(Clients));
            }
        }

        private bool isAddButtonEnabled = false;
        public bool IsAddButtonEnabled
        {
            get => isAddButtonEnabled;
            set
            {
                isAddButtonEnabled = value;
                OnPropertyChanged(nameof(IsAddButtonEnabled));
            }
        }

        private bool isBalanceChangeEnabled = false;
        public bool IsBalanceChangeEnabled
        {
            get => isBalanceChangeEnabled;
            set
            {
                isBalanceChangeEnabled = value;
                OnPropertyChanged(nameof(isBalanceChangeEnabled));
            }
        }
        // --------------------------------------------------------------------------------------------------------------
        // End Attributes
        // --------------------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            
            WithdrawPanel.Visibility = (IsBalanceChangeEnabled ? Visibility.Visible : Visibility.Collapsed);
        }

        private void UpdControls()
        {
            IsAddButtonEnabled = (BalanceTB.Text != "");
        }

        private static string GetRandomName()
        {
            const string fileName = @"..\..\..\RandNames.txt";

            string retVal = string.Empty;

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                if (lines.Length > 0)
                {
                    Random rand = new Random();
                    int randIndex = rand.Next(0, lines.Length);
                    return lines[randIndex];
                }
            }
            return retVal;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation
            bool isValid = double.TryParse(BalanceTB.Text.Replace('.', ','), out double convertedValue);
            if (!isValid)
            {
                MessageBox.Show("Bitte einen validen Wert eingeben...");
                BalanceTB.Text = string.Empty;
                BalanceTB.Focus();
                return;
            }
            // hint for user
            if (convertedValue <= Client.LIMIT)
                MessageBox.Show("Der Kontostand wird auf das untere Limit gesetzt, da ihre Eingabe kleiner war...");

            string nameValue = NameTB.Text;
            if (string.IsNullOrEmpty(nameValue)) 
            {
                nameValue = GetRandomName();
            }

            Clients.Add(new Client { Name = nameValue, Balance = convertedValue });

            NameTB.Text = string.Empty;
            BalanceTB.Text = string.Empty;
        }

        private void BalanceTB_TextChanged(object sender, RoutedEventArgs e)
        {
            UpdControls();
        }

        private void NameTB_TextChanged(object sender, RoutedEventArgs e)
        {
            UpdControls();
        }

        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsBalanceChangeEnabled = (ClientList.SelectedItem != null);
            WithdrawPanel.Visibility = (IsBalanceChangeEnabled ? Visibility.Visible : Visibility.Collapsed);
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var client in Clients)
            {
                if ((Client)ClientList.SelectedItem == client)
                {
                    bool isValid = double.TryParse(ChangeBalanceValue.Text.Replace('.', ','), out double convertedValue);

                    if (!isValid)
                    {
                        MessageBox.Show("Bitte einen validen Wert eingeben...");
                        ChangeBalanceValue.Text = string.Empty;
                        ChangeBalanceValue.Focus();
                        return;
                    }

                    client.GeldAbheben(convertedValue);
                    ChangeBalanceValue.Text = string.Empty;
                    break;
                }
            }
        }

        private void DebtsButton_Click(object sender, RoutedEventArgs e)
        {
            string output = string.Empty;
            foreach (var client in Clients)
            {
                if (client.Balance < 0.0)
                    output += client.Name + " mit " + ((-1) * client.Balance) + "€ Schulden\n"; 
            }

            MessageBox.Show((output == "") ? "Zurzeit hat kein Kunde Schulden" : output);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var client in Clients)
            {
                if ((Client)ClientList.SelectedItem == client)
                {
                    if (MessageBox.Show("Möchten Sie das Kundenkonto unwiderruflich löschen?", "Kundenkonto löschen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Clients.Remove(client);
                        break;
                    }
                }
            }
        }
    }
}