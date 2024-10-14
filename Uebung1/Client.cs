using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung1
{
    public class Client : INotifyPropertyChanged
    {
        // Public because of a message to the user
        public const double LIMIT = -100.0;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? name;
        public string? Name
        {
            get => name;
            set => name = value;
        }

        private double? balance;
        public double? Balance 
        {
            get { return balance; }
            set
            {
                if (value > LIMIT)
                    balance = value;
                else
                    balance = LIMIT;

                OnPropertyChanged(nameof(Balance));
            }
        }

        public double? GeldAbheben(double value)
        {
            if (Balance - value > LIMIT)
                Balance -= value;
            else
                Balance = LIMIT;

            return Balance;
        }
    }
}
