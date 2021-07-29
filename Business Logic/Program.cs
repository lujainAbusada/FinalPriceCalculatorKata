using System;
using System.Collections.Generic;

namespace PriceCalculatorKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First Test Case:");
            Currency currency = new Currency("USD");
            Product Book = new Product("The Little Prince Book", 12345, new Price(20.25, currency), 0.07);
            Tax tax = new Tax(0.2);
            UniversalDiscount universal = new UniversalDiscount(0.15, DiscountType.after);
            UpcDiscount upc = new UpcDiscount(Book.UpcDiscount, DiscountType.after);
            Expenses expenses = new Expenses("0", "0", "0");
            Cap cap = new Cap("100%");
            List<IDiscount> discounts = new List<IDiscount>
            {
                upc,
                universal
            };
            DiscountCalculator discountCalculator = new AdditiveDiscountCalculator(discounts);
            PriceCalculator priceCalculator = new PriceCalculator(Book, tax, discountCalculator, expenses, cap);
            new PurchaseReport(priceCalculator, null).PrintReport();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("Second Test Case:");
            currency = new Currency("USD");
            Book = new Product("The Little Prince Book", 12345, new Price(20.25, currency), 0.07);
            tax = new Tax(0.2);
            universal = new UniversalDiscount(0.15, DiscountType.after);
            upc = new UpcDiscount(Book.UpcDiscount, DiscountType.before);
            expenses = new Expenses("0", "0", "0");
            cap = new Cap("100%");
            discounts = new List<IDiscount>
            {
                upc,
                universal
            };
            discountCalculator = new AdditiveDiscountCalculator(discounts);
            priceCalculator = new PriceCalculator(Book, tax, discountCalculator, expenses, cap);
            new PurchaseReport(priceCalculator, null).PrintReport();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("Third Test Case:");
            currency = new Currency("USD");
            Book = new Product("The Little Prince Book", 12345, new Price(20.25, currency), 0.07);
            tax = new Tax(0.21);
            universal = new UniversalDiscount(0.15, DiscountType.after);
            upc = new UpcDiscount(Book.UpcDiscount, DiscountType.after);
            expenses = new Expenses("2.2", "1%", "0");
            cap = new Cap("100%");
            discounts = new List<IDiscount>
            {
                upc,
                universal
            };
            discountCalculator = new MultiplicativeDiscountCalculator(discounts);
            priceCalculator = new PriceCalculator(Book, tax, discountCalculator, expenses, cap);
            new PurchaseReport(priceCalculator, null).PrintReport();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("Fourth Test Case (Currency Conversion):");
            currency = new Currency("USD");
            Book = new Product("The Little Prince Book", 12345, new Price(20.25, currency), 0.07);
            tax = new Tax(0.21);
            universal = new UniversalDiscount(0.15, DiscountType.after);
            upc = new UpcDiscount(Book.UpcDiscount, DiscountType.after);
            expenses = new Expenses("2.2", "1%", "0");
            cap = new Cap("100%");
            discounts = new List<IDiscount>
            {
                upc,
                universal
            };
            discountCalculator = new MultiplicativeDiscountCalculator(discounts);
            priceCalculator = new PriceCalculator(Book, tax, discountCalculator, expenses, cap);
            new PurchaseReport(priceCalculator, new CurrencyExchange(new Currency("USD"), new Currency("NIS"), 3.5)).PrintReport();
        }
    }
}
