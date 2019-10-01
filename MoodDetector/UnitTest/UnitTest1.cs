using System;
using Xunit;
namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void FirstFact()
        {
            Assert.Equal(2, 1 + 1);
        }
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 2)]
        public void FirstTheory(int add1, int add2, int expectedSum)
        {
            Assert.Equal(expectedSum, add1 + add2);
        }
    }
}
