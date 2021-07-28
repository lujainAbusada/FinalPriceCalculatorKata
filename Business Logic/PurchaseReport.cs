using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    internal class PurchaseReport
    {
        private readonly PriceCalculator _priceCalculator;
        private readonly CurrencyExchange? _currencyExchange = null;

        public PurchaseReport(PriceCalculator priceCalculator, CurrencyExchange currencyExchange)
        {
            _priceCalculator = priceCalculator;
            _currencyExchange = currencyExchange;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Cost = {Math.Round(_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Amount,2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}");
            Console.WriteLine($"Tax = {Math.Round(_priceCalculator.Tax.CalculateTax(_priceCalculator.Discount.CalculatePriceBeforeTax(_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Amount)), 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}");
            Console.WriteLine($"Transport Cost = {Math.Round(_priceCalculator.Expenses.CalculateTransportCost(_priceCalculator.PurchasedProduct.Price).CalculateCurrencyExchange(_currencyExchange).Amount, 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}");
            Console.WriteLine($"Packaging Cost = {Math.Round(_priceCalculator.Expenses.CalculatePackagingCost(_priceCalculator.PurchasedProduct.Price).CalculateCurrencyExchange(_currencyExchange).Amount, 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}");
            Console.WriteLine($"Administrative Cost = {Math.Round(_priceCalculator.Expenses.CalculateAdministrativeCost(_priceCalculator.PurchasedProduct.Price).CalculateCurrencyExchange(_currencyExchange).Amount, 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}");
            Console.WriteLine("Total = " + _priceCalculator.CalculateFinalPrice().CalculateCurrencyExchange(_currencyExchange).Tostring());
            Console.WriteLine(DiscountStringFormatter());
        }

        public string DiscountStringFormatter()
        {
            return _priceCalculator.CalculateDeducedPrice().Amount == 0 ? string.Empty : $"{Math.Round(_priceCalculator.CalculateDeducedPrice().CalculateCurrencyExchange(_currencyExchange).Amount, 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name}";
        }
    }
}
