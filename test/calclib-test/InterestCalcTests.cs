using System;
using Xunit;
using DotnetSPA;

namespace DotnetSPATests
{
    public class InterestCalcTests
    {
        [Fact]
        public void UT_GetFinalBalance_should_return_correct_value()
        {
            Assert.Equal(8, InterestCalculator.GetFinalBalance(1, 1, 3));
            Assert.Equal(1, InterestCalculator.GetFinalBalance(4, -0.5, 2));
        }

        [Fact]
        public void UT_negative_balance_should_throw()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                InterestCalculator.GetFinalBalance(-1, 0.05, 10));
            Assert.True(ex.Message.StartsWith("originalBalance cannot be negative"));
        }

        [Fact]
        public void UT_negative_years_should_throw()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                InterestCalculator.GetFinalBalance(1, 0.05, -10));
            Assert.True(ex.Message.StartsWith("years cannot be negative"));
        }
    }
}
