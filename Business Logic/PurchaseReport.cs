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
            var OriginalPrice = _priceCalculator.PurchasedProduct.Price;
            var OriginalPriceAfterExchange = OriginalPrice.CalculateCurrencyExchange(_currencyExchange);
            var Tax = _priceCalculator.Tax.CalculateTax(_priceCalculator.Discount.CalculatePriceBeforeTax(OriginalPriceAfterExchange.Amount));
            var TransportCost = Math.Round(_priceCalculator.Expenses.CalculateTransportCost(OriginalPrice).CalculateCurrencyExchange(_currencyExchange).Amount, 2);
            var PackagingCost = Math.Round(_priceCalculator.Expenses.CalculatePackagingCost(OriginalPrice).CalculateCurrencyExchange(_currencyExchange).Amount, 2);
            var administrativeCost = Math.Round(_priceCalculator.Expenses.CalculateAdministrativeCost(OriginalPrice).CalculateCurrencyExchange(_currencyExchange).Amount, 2);
            var finalPrice = _priceCalculator.CalculateFinalPrice().CalculateCurrencyExchange(_currencyExchange);
            Console.WriteLine($"Cost = {Math.Round(OriginalPriceAfterExchange.Amount,2)} {OriginalPriceAfterExchange.Currency.Name}");
            Console.WriteLine($"Tax = {Math.Round(Tax,2)} {OriginalPriceAfterExchange.Currency.Name}");
            Console.WriteLine($"Transport Cost = {TransportCost} {OriginalPriceAfterExchange.Currency.Name}");
            Console.WriteLine($"Packaging Cost = {PackagingCost} {OriginalPriceAfterExchange.Currency.Name}");
            Console.WriteLine($"Administrative Cost = {administrativeCost} {OriginalPriceAfterExchange.Currency.Name}");
            Console.WriteLine($"Total = {finalPrice.ToString()}");
            Console.WriteLine(DiscountStringFormatter());
        }

        public string DiscountStringFormatter()
        {
            return _priceCalculator.CalculateDeducedPrice().Amount == 0 ? string.Empty : $"{Math.Round(_priceCalculator.CalculateDeducedPrice().CalculateCurrencyExchange(_currencyExchange).Amount, 2)} {_priceCalculator.PurchasedProduct.Price.CalculateCurrencyExchange(_currencyExchange).Currency.Name} was deduced from the final price";
        }
    }
}
