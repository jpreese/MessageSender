﻿using PackageShipper.Rules;
using System.Collections.Generic;

namespace PackageShipper
{
    internal class PriceCalculator : ICalculator
    {
        private readonly IList<IPriceRule> _priceRules;

        public PriceCalculator(IList<IPriceRule> priceRules)
        {
            _priceRules = priceRules;
        }

        public int Calculate(string message)
        {
            var price = 0;

            foreach(var priceRule in _priceRules)
            {
                if(priceRule.AppliesTo(message))
                {
                    price = priceRule.Apply(price);
                }
            }

            return price;
        }
    }
}