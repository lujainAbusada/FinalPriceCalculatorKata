using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Price
    {
        internal double Amount { get; private set; }
        internal Currency Currency { get; private set; }

        public Price(double amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        override
        public string ToString()
        {
            return Amount + " " + Currency.Name;
        }
    }
}
