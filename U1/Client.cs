using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1
{
    public class Client : INotifyPropertyChanged
    {
        private string _name = "";
        private double? _balance = 0.0;
        // Public because of hint for user
        public static readonly double LIMIT = -1000.0;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double? Balance
        {
            get => _balance;
            set
            {
                if (value <= LIMIT)
                    _balance = LIMIT;
                else
                    _balance = value;

                OnPropertyChanged(nameof(Balance));
            }
        }

        public double? DebitMoney(double value)
        {
            Balance -= value;
            return Balance;
        }
    }
}
