using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculatorKata
{
    internal class MultiplicativeDiscountCalculator : DiscountCalculator
    {
        public MultiplicativeDiscountCalculator(List<IDiscount> allDiscounts) : base(allDiscounts)
        {
        }

        public override double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax)
        {
            var deducedAmountAfterTax = 0.0;
            foreach (IDiscount discount in discountsAfterTax)
                deducedAmountAfterTax += discount.CalculateDiscount(price - deducedAmountAfterTax);
            return deducedAmountAfterTax;
        }

        public override double  CalculateDiscountsBeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount discount in discountsBeforeTax)
                deducedAmountBeforeTax += discount.CalculateDiscount(price - deducedAmountBeforeTax);
            return deducedAmountBeforeTax;
        }
    }
}
