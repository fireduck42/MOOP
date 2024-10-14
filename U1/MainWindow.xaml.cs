using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace U1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients = [];
        private ObservableCollection<Client> _secondClientList = [];
        private bool _isValidClient = false;
        private Visibility _isDebitable = Visibility.Collapsed;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public bool IsValidClient
        {
            get => _isValidClient;
            set
            {
                _isValidClient = value;
                OnPropertyChanged(nameof(IsValidClient));
            }
        }

        public Visibility IsDebitable
        {
            get => _isDebitable;
            set
            {
                _isDebitable = value;
                OnPropertyChanged(nameof(IsDebitable));
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            Clients =
            [
                new Client { Name = GetRandomName(), Balance = 200.0 },
                new Client { Name = GetRandomName(), Balance = -100.0 },
                new Client { Name = GetRandomName(), Balance = 10.0 },
            ];

            _secondClientList =
            [
                new Client { Name = GetRandomName(), Balance = 4000.0 },
                new Client { Name = GetRandomName(), Balance = 100.0 },
                new Client { Name = GetRandomName(), Balance = 13.22 },
                new Client { Name = GetRandomName(), Balance = 15.5 },
            ];

            foreach (var client in _secondClientList )
                Clients.Add(client);
        }

        // Only need to check balance because Name could be empty
        private static bool IsBalanceValid(string balanceValue)
        {
            if (balanceValue is null)
                return false;

            if (double.TryParse(balanceValue, out double newBalance))
            {
                if (newBalance < Client.LIMIT)
                    return false;

                return true;
            }
            else
                return false;
        }

        private static string GetRandomName()
        {
            string path = @"..\..\..\RandNames.txt";
            if (!File.Exists(path))
                return string.Empty;

            string[] names = File.ReadAllLines(path);
            if (names.Length == 0)
                return string.Empty;

            Random random = new();
            int randomIndex = random.Next(0, names.Length);

            // Return the random name
            return names[randomIndex];
        }


        private void Balance_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidClient = IsBalanceValid(NewClientBalance.Text);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidClient = IsBalanceValid(NewClientBalance.Text);
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            if (!_isValidClient)
                return;

            double newBalance = double.Parse(NewClientBalance.Text);
            string newName = string.IsNullOrEmpty(NewClientName.Text) ? GetRandomName() : NewClientName.Text;

            Clients.Add(new Client { Name = newName, Balance = newBalance });
            NewClientBalance.Text = string.Empty;
            NewClientName.Text = string.Empty;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientList.SelectedItems.Count > 0)
                IsDebitable = Visibility.Visible;
            else
                IsDebitable = Visibility.Collapsed;
        }

        private void Debit_Clicked(object sender, RoutedEventArgs e)
        {
            if (ClientList.SelectedItem is not Client selectedClient)
                return;

            string debitBalance = NewDebitBalance.Text;
            if (string.IsNullOrEmpty(debitBalance) || !IsBalanceValid(debitBalance))
                return;

            double debitValue = double.Parse(debitBalance);
            foreach (Client client in Clients)
            {
                if (client == selectedClient)
                {
                    client.DebitMoney(debitValue);
                    NewDebitBalance.Text = string.Empty;
                    break;
                }
            }
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientList.SelectedItem is not Client selectedClient)
                return;

            // not override while iterating
            var deleteList = Clients;
            foreach (Client client in deleteList)
            {
                if (client == selectedClient)
                {
                    Clients.Remove(client);
                    break;
                }
            }
        }

        private void GetDebtors_Clicked(object sender, RoutedEventArgs e)
        {
            string debtors = string.Empty;
            foreach (Client client in Clients)
            {
                if (client.Balance < 0.0)
                    debtors += client.Name + " with $" + (client.Balance * (-1)).ToString() + " debts\n"; 
            }

            MessageBox.Show(debtors ?? "No client has debts", "Debtors", MessageBoxButton.OK);
        }
    }
}