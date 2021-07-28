using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculatorKata
{
    internal abstract class DiscountCalculator
    {
        public List<IDiscount> AllDiscounts { get; private set; }

        public DiscountCalculator (List<IDiscount> allDiscounts)
        {
            AllDiscounts = allDiscounts;
        }

        public abstract double CalculateDiscountsAfterTax(double price, List<IDiscount> discountsAfterTax);
        public abstract double CalculateDiscountsBeforeTax(double price, List<IDiscount> discountsBeforeTax);

        public double CalculateTotalDiscount(double price)
        {
            var discountBeforeTax = CalculateDiscountsBeforeTax(price, (from s in AllDiscounts
                                                                        where s.Type.Equals(DiscountType.before)
                                                                        select s).ToList());
            var discountAfterTax = CalculateDiscountsBeforeTax(price - discountBeforeTax, (from s in AllDiscounts
                                                                                           where s.Type.Equals(DiscountType.after)
                                                                                           select s).ToList());
            return discountAfterTax + discountBeforeTax;

        }

        public double CalculatePriceBeforeTax(double price)
        {
            return price - CalculateDiscountsBeforeTax(price, (from s in AllDiscounts
                                                               where s.Type.Equals(DiscountType.before)
                                                               select s).ToList());
        }
    }
}
