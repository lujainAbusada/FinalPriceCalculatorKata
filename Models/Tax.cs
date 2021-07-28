using System;

namespace PriceCalculatorKata
{
    internal class Tax
    {
        public readonly double _taxRate;

        public Tax(double taxRate)
        {
            _taxRate = taxRate;
        }

        public double CalculateTax(double price)
        {
            return Math.Round(price * _taxRate, 4);
        }
    }
}
