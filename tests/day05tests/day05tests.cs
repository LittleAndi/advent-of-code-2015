using System;
using Xunit;
using Shouldly;

namespace day05tests
{
    using day05;
    public class Day05Tests
    {
        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void Test1(string input, bool expected)
        {
            var non = new NaughtyOrNice{ Input = input };
            non.IsNice.ShouldBe(expected);
        }
    }
}
