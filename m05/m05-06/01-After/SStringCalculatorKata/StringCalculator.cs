using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SStringCalculatorKata
{
    public class StringCalculator
    {
        public decimal Add(String numbers){

            decimal returnValue = 0;

            if (Decimal.TryParse(numbers, out decimal result)) returnValue = result;

            if (numbers.Contains(",")){
                Array.ForEach(numbers.Split(","), i => returnValue += Decimal.Parse(i));
            }

            return returnValue;
        }

        public decimal Subtract(String numbers){

            decimal returnValue = 0;

            if (Decimal.TryParse(numbers, out decimal result)) returnValue = result;

            return returnValue;
        }
    }
}