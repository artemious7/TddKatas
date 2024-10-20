namespace FizzBuzzWithATwist.Approach2.Tests;

using Implementation;

public class FizzBuzzerTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "fizz")]
    [InlineData(6, "fizz")]
    [InlineData(5, "buzz")]
    [InlineData(10, "buzz")]
    [InlineData(15, "fizz buzz")]
    [InlineData(30, "fizz buzz")]
    public void Tests(int number, string expected)
    {
        var fizzBuzzer = new FizzBuzzer();
        var result = fizzBuzzer.FizzBuzzIt(number);
        result.Should().Be(expected);
    }
}
