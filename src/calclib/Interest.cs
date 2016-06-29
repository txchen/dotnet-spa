using System;

namespace DotnetSPA
{
    public class InterestCalculator
    {
        public static double GetFinalBalance(double originalBalance, double interestRate, int years)
        {
            if (originalBalance < 0)
            {
                throw new ArgumentException("originalBalance cannot be negative", nameof(originalBalance));
            }
            if (years < 0)
            {
                throw new ArgumentException("years cannot be negative", nameof(years));
            }

            double result = originalBalance;
            for (int i = 0; i < years; i++)
            {
                result *= (1 + interestRate);
            }
            return result;
        }
    }
}
