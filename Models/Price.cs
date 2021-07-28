using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Price
    {
        private double _amount;
        private Currency _currency;

        public double Amount { get => _amount; }
        internal Currency Currency { get => _currency; }

        public Price(double amount, Currency currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public string Tostring()
        {
            return Amount +" " +Currency.Name;
        }
    }
}
