using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class PriceCalculator
    {
        private readonly Product _purchasedProduct;
        private readonly Expenses _expenses;
        private readonly Cap _cap;
        private readonly Tax _tax;
        private readonly IDiscountCalculator _discount;


        internal Product PurchasedProduct { get => _purchasedProduct; }
        internal Tax Tax { get => _tax; }
        internal Expenses Expenses => _expenses;
        internal IDiscountCalculator Discount => _discount;

        public PriceCalculator(Product product, Tax tax, IDiscountCalculator discountCalculator, Expenses expenses, Cap cap)
        {
            _purchasedProduct = product;
            _tax = tax;
            _cap = cap;
            _expenses = expenses;
            _discount = discountCalculator;
        }

        public Price CalculateFinalPrice()
        {
            return new Price(Math.Round(_purchasedProduct.Price.Amount
                + _tax.CalculateTax(Discount.CalculatePriceBeforeTax(_purchasedProduct.Price.Amount))
                - CalculateDeducedPrice().Amount
                + Expenses.CalculateTotalExpenses(_purchasedProduct.Price).Amount, 2), _purchasedProduct.Price.Currency);
        }

        public Price CalculateDeducedPrice()
        {
            return new Price(CheckCap(Discount.CalculateTotalDiscount(_purchasedProduct.Price.Amount)), _purchasedProduct.Price.Currency);
        }

        private double CheckCap(double deducedAmount)
        {
            if (deducedAmount > _cap.CalculateCap(_purchasedProduct.Price.Amount))
                return _cap.CalculateCap(_purchasedProduct.Price.Amount);
            else
                return deducedAmount;
        }

        private Price ChangeCurrency(CurrencyExchange currencyExchange)
        {
            return _purchasedProduct.Price.CalculateCurrencyExchange(currencyExchange);
        }
    }
}
