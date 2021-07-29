using System;

namespace PriceCalculatorKata
{
    internal class Expenses
    {
        private readonly string _transportCost;
        private readonly string _packagingCost;
        private readonly string _administrativeCost;
        private const string _percentage = "%";


        public Expenses(string transportCost, string packagingCost, string administrativeCost)
        {
            _transportCost = transportCost;
            _packagingCost = packagingCost;
            _administrativeCost = administrativeCost;
        }

        private double CalculateExpenseValue(double purchasedProductPriceAmount, string expense)
        {
            return expense.Contains(_percentage) ? purchasedProductPriceAmount * Double.Parse(expense.Replace(_percentage, "")) / 100 : Double.Parse(expense);
        }

        public  Price CalculateTotalExpenses(Price purchasedProductPrice)
        {
            return new Price( Math.Round(CalculateTransportCost(purchasedProductPrice).Amount +
                CalculatePackagingCost(purchasedProductPrice).Amount +
                CalculateAdministrativeCost(purchasedProductPrice).Amount, 4), purchasedProductPrice.Currency);
        }

        public Price CalculateAdministrativeCost(Price purchasedProductPrice)
        {
            return new Price(CalculateExpenseValue(purchasedProductPrice.Amount, _administrativeCost), purchasedProductPrice.Currency);
        }

        public Price CalculatePackagingCost(Price purchasedProductPrice)
        {
            return new Price(CalculateExpenseValue(purchasedProductPrice.Amount, _packagingCost), purchasedProductPrice.Currency);
        }

        public Price CalculateTransportCost(Price purchasedProductPrice)
        {
            return new Price(CalculateExpenseValue(purchasedProductPrice.Amount, _transportCost),purchasedProductPrice.Currency);
        }
    }
}
