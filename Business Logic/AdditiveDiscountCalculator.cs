using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    internal class AdditiveDiscountCalculator : DiscountCalculator
    {
        public AdditiveDiscountCalculator(List<IDiscount> allDiscounts) : base(allDiscounts)
        {
        }

        override
        public double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax)
        {
            var deducedAmountAfterTax = 0.0;
            foreach (IDiscount Discount in discountsAfterTax)
                deducedAmountAfterTax += Discount.CalculateDiscount(price);
            return deducedAmountAfterTax;
        }

        override
        public double CalculateDiscountsBeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount discount in discountsBeforeTax)
                deducedAmountBeforeTax += discount.CalculateDiscount(price);
            return deducedAmountBeforeTax;
        }
    }
}
