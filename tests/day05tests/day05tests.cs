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
        public void TestIsNice(string input, bool expected)
        {
            var non = new NaughtyOrNice { Input = input };
            non.IsNice.ShouldBe(expected);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", true)]
        [InlineData("haegwjzuvuyypxyu", true)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void TestVowels(string input, bool expected)
        {
            var non = new NaughtyOrNice { Input = input };
            non.ContainsAtLeastThreeVowels.ShouldBe(expected);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", true)]
        [InlineData("dvszwmarrgswjxmb", true)]
        public void TestRepeatingLetters(string input, bool expected)
        {
            var non = new NaughtyOrNice { Input = input };
            non.ContainsRepeatingLetters.ShouldBe(expected);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb", true)]
        [InlineData("xxyxx", true)]
        [InlineData("uurcxstgmygtbstg", false)]
        [InlineData("ieodomkazucvgmuy", true)]
        [InlineData("ieodfmkazucvgmuy", false)]
        public void TestRepeatingLettersWithSpace(string input, bool expected)
        {
            var non = new NaughtyOrNice { Input = input };
            non.ContainsRepeatingLettersWithSpace.ShouldBe(expected);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", false)]
        [InlineData("aaa", false)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", true)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void TestInvalidStrings(string input, bool expected)
        {
            var non = new NaughtyOrNice { Input = input };
            non.ContainsInvalidStrings.ShouldBe(expected);
        }
    }
}
