namespace CombinedNumber;

public class NumberHelpersTests
{
    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(2, 1, true)]
    [InlineData(1, 2, false)]
    [InlineData(5, 50, true)]
    [InlineData(50, 5, false)]
    public void TestIsXYGreaterThanOrEqualToYX(int x, int y, bool expected)
    {
        Assert.Equal(expected, NumberHelpers.IsXYGreaterThanOrEqualToYX(x, y));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(9, 0)]
    [InlineData(10, 1)]
    [InlineData(99, 1)]
    [InlineData(100, 2)]
    public void TestPowerOf(int x, int expected)
    {
        Assert.Equal(expected, NumberHelpers.PowerOf(x));
    }
}
