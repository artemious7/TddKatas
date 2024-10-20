namespace FizzBuzzWithATwist.Approach2.Tests;

using Implementation;

public class OrderingExpertTests
{
    [Theory]
    [InlineData(new int[] { }, Ordering.AscendingOrUnknown)]
    [InlineData(new[] { 1, 2 }, Ordering.AscendingOrUnknown)]
    [InlineData(new[] { 1, 2, 0 }, Ordering.AscendingOrUnknown)]
    [InlineData(new[] { 2, 1 }, Ordering.Descending)]
    [InlineData(new[] { 2, 1, 3 }, Ordering.Descending)]
    [InlineData(new[] { 2, 1, 3, 4 }, Ordering.Descending)]
    [InlineData(new[] { 2, 1, 3, 1 }, Ordering.Descending)]
    public void Tests(int[] array, Ordering expected)
    {
        var orderingExpert = new OrderingExpert();
        var result = orderingExpert.DetermineOrder(array);
        result.Should().Be(expected);
    }
}
