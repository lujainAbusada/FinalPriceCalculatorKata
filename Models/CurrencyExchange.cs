using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class CurrencyExchange
    {
        private readonly Currency _from;
        private readonly Currency _to;
        private readonly Double _exchangeRate;

        public double ExchangeRate => _exchangeRate;

        internal Currency From => _from;

        internal Currency To => _to;


        public CurrencyExchange(Currency from, Currency to, double exchangeRate)
        {
            _from = from;
            _to = to;
            _exchangeRate = exchangeRate;
        }


    }
}
