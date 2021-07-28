using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class CurrencyExchange
    {
        public double ExchangeRate { get; private set; }
        internal Currency From { get; private set; }
        internal Currency To { get; private set; }

        public CurrencyExchange(Currency from, Currency to, double exchangeRate)
        {
            From = from;
            To = to;
            ExchangeRate = exchangeRate;
        }


    }
}
