using System.Linq;
using Xunit;

namespace UnitTest.Service.AggregateTest
{
    public class AggregateTest
    {
        [Fact]
        public void TestAggregate()
        {
            int[] numbers = { 84, 541, 2, 1, 326, 1111, 32, 9 };

            Assert.Equal(1, numbers.Aggregate((lowestNumber, number) => number < lowestNumber ? number : lowestNumber));
            Assert.Equal(263.25, (double) numbers.Aggregate((n1, n2) => n1 + n2) / numbers.Count());
        }
    }
}
