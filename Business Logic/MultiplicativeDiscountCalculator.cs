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

        override
        public double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax)
        {
            var deducedAmountAfterTax = 0.0;
            foreach (IDiscount Discount in discountsAfterTax)
                deducedAmountAfterTax += Discount.CalculateDiscount(price - deducedAmountAfterTax);
            return deducedAmountAfterTax;
        }

        override
        public double CalculateDiscountsBeforeTax(double price, List<IDiscount> discountsBeforeTax)
        {
            var deducedAmountBeforeTax = 0.0;
            foreach (IDiscount Discount in discountsBeforeTax)
                deducedAmountBeforeTax += Discount.CalculateDiscount(price - deducedAmountBeforeTax);
            return deducedAmountBeforeTax;
        }
    }
}
