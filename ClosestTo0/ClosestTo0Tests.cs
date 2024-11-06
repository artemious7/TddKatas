namespace ClosestTo0;

public class ClosestTo0Tests
{
    [Theory]
    [InlineData((int[])[0], 0)]
    [InlineData((int[])[0, 0], 0)]
    [InlineData((int[])[1, 0], 0)]
    [InlineData((int[])[1, 2], 1)]
    [InlineData((int[])[-2, 1], 1)]
    [InlineData((int[])[-2, 3], -2)]
    [InlineData((int[])[-2, 2], 2)]
    [InlineData((int[])[2, -2], 2)]
    public void Tests(int[] input, int expected)
    {
        Assert.Equal(expected, ClosestTo0.Approach1(input));
        Assert.Equal(expected, ClosestTo0.Approach2(input));
        Assert.Equal(expected, ClosestTo0.Approach3(input));
    }

}