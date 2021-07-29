using System;

namespace PriceCalculatorKata
{
    internal class Product
    {
        public string Name { get; private set; }
        public int Upc { get; private set; }
        public double UpcDiscount { get; private set; }
        internal Price Price { get; private set; }

        public Product(string name, int upc, Price price, double upcDiscount)
        {
            Name = name;
            Upc = upc;
            Price = price;
            UpcDiscount = upcDiscount;
        }
    }
}
