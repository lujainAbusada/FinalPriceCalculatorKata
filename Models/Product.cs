using System;

namespace PriceCalculatorKata
{
    internal class Product
    {
        private readonly string _name;
        private readonly int _upc;
        private readonly double _upcDiscount;
        private readonly Price _price;

        public string Name => _name;
        public int Upc => _upc;
        public double UpcDiscount => _upcDiscount;
        internal Price Price => _price;

        public Product(string name, int upc, Price price, double upcDiscount)
        {
            _name = name;
            _upc = upc;
            _price = price;
            _upcDiscount = upcDiscount;
        }
    }
}
