namespace FizzBuzzWithATwist.Approach2.Tests;

using Implementation;

public class StringReverserTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("15", "15")]
    [InlineData("ab", "ba")]
    [InlineData("fizz", "zzif")]
    [InlineData("fizz buzz", "zzub zzif")]
    public void Tests(string input, string expected)
    {
        var reverser = new StringReverser();
        var result = reverser.Reverse(input);
        result.Should().Be(expected);
    }
}
