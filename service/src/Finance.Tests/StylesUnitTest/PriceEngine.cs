namespace Finance.Tests.StylesUnitTest
{
    using System;

    public class PriceEngine
    {
        public decimal CalculateDiscount(
            params Product[] product)
        {
            decimal discount = product.Length * 0.01m;
            return Math.Min(discount, 0.2M);
        }
    }
}