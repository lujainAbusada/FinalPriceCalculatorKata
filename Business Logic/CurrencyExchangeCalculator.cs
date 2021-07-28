using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    static class CurrencyExchangeCalculator
    {
        static public Price CalculateCurrencyExchange(this Price price, CurrencyExchange? currencyExchange)
        {
            return currencyExchange == null ? price : new Price(price.Amount * currencyExchange.ExchangeRate, currencyExchange.To);
        }
    }
}
