﻿using DDDInPractice.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace DDDInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            Money mone1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = mone1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }
    }
}
