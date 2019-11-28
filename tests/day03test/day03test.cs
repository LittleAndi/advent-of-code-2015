using System;
using Xunit;
using Shouldly;

namespace day03tests
{
    using day03;

    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0, 0, true)]
        [InlineData(-1, 1, 1, -1, false)]
        [InlineData(0, 0, 1, 1, false)]
        [InlineData(0, 1, 2, 3, false)]
        [InlineData(-1, -1, -1, -1, true)]
        [InlineData(1, 1, 1, 1, true)]
        public void TestPositionEquals(int x1, int y1, int x2, int y2, bool expectedResult)
        {
            var p1 = new Position
            {
                X = x1,
                Y = y1
            };

            var p2 = new Position
            {
                X = x2,
                Y = y2
            };

            p1.Equals(p2).ShouldBe(expectedResult);

        }
    
        [Theory]
        [InlineData(0, 0, '>', 1, 0)]
        [InlineData(0, 0, 'v', 0, 1)]
        [InlineData(0, 0, '<', -1, 0)]
        [InlineData(0, 0, '^', 0, -1)]
        public void TestMove(int x, int y, char direction, int newX, int newY)
        {
            var pos = new Position{X = x, Y = y};
            pos.Move(direction);
            pos.X.ShouldBe(newX);
            pos.Y.ShouldBe(newY);
        }
    }
}
