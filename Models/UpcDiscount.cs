using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class UpcDiscount : IDiscount
    {
        public double Amount { get; private set; }
        public DiscountType Type { get; private set; }

        public UpcDiscount(double amount, DiscountType type)
        {
            Amount = amount;
            Type = type;
        }

        public double CalculateDiscount(double price)
        {
            return Math.Round(price * Amount, 4);
        }
    }
}