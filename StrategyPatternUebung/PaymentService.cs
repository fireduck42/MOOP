using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternUebung
{
    public class PaymentService
    {
        private IStrategy? _strategy;

        public PaymentService()
        {}

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Pay(double value)
        {
            if (_strategy == null)
                return;

            _strategy.Execute(value);
        }
    }
}
