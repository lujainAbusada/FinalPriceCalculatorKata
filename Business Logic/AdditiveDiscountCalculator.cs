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

        public override double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax)
        {
            var deducedAmountAfterTax = 0.0;
            foreach (IDiscount discount in discountsAfterTax)
                deducedAmountAfterTax += discount.CalculateDiscount(price);
            return deducedAmountAfterTax;
        }

        public override double CalculateDiscountsBeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount discount in discountsBeforeTax)
                deducedAmountBeforeTax += discount.CalculateDiscount(price);
            return deducedAmountBeforeTax;
        }
    }
}
