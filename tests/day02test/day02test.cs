using System;
using Xunit;
using Shouldly;

namespace day02test
{
    using day02;

    public class Day02Test
    {
        [Theory]
        [InlineData(2, 3, 4, 52)]
        [InlineData(1, 1, 10, 42)]
        public void TestWrappingPaper(int l, int w, int h, int expectedWrappingPaper)
        {
            var present = new Present
            {
                Length = l,
                Width = w,
                Height = h
            };

            present.WrappingPaper.ShouldBe(expectedWrappingPaper);
        }

        [Theory]
        [InlineData(2, 3, 4, 6)]
        [InlineData(1, 1, 10, 1)]
        public void TestSlack(int l, int w, int h, int expectedSlack)
        {
            var present = new Present
            {
                Length = l,
                Width = w,
                Height = h
            };

            present.Slack.ShouldBe(expectedSlack);
        }
    }
}
