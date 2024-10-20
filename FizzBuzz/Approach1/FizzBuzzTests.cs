namespace FizzBuzzWithATwist.Approach1;

public class FizzBuzzTests
{
    [Theory]
    // 0 elements
    [InlineData(new int[] { }, new string[] { })]

    // 1 element
    [InlineData(new[] { 1 }, new[] { "1" })]
    [InlineData(new[] { 3 }, new[] { "fizz" })]
    [InlineData(new[] { 5 }, new[] { "buzz" })]
    [InlineData(new[] { 15 }, new[] { "fizz buzz" })]

    // 2 elements, ascending
    [InlineData(new[] { 1, 2 }, new[] { "1", "2" })]
    [InlineData(new[] { 1, 3 }, new[] { "1", "fizz" })]
    [InlineData(new[] { 1, 5 }, new[] { "1", "buzz" })]
    [InlineData(new[] { 1, 15 }, new[] { "1", "fizz buzz" })]

    // 2 elements, descending
    [InlineData(new[] { 2, 1 }, new[] { "2", "1" })]
    [InlineData(new[] { 3, 1 }, new[] { "zzif", "1" })]
    [InlineData(new[] { 5, 1 }, new[] { "zzub", "1" })]
    [InlineData(new[] { 15, 1 }, new[] { "zzub zzif", "1" })]
    [InlineData(new[] { 22, 13 }, new[] { "22", "13" })]

    // 3 elements, ascending
    [InlineData(new[] { 1, 2, 4 }, new[] { "1", "2", "4" })]
    [InlineData(new[] { 1, 2, 3 }, new[] { "1", "2", "fizz" })]
    [InlineData(new[] { 1, 2, 5 }, new[] { "1", "2", "buzz" })]
    [InlineData(new[] { 1, 2, 15 }, new[] { "1", "2", "fizz buzz" })]

    // 3 elements, descending, numbers only in the output
    [InlineData(new[] { 4, 2, 1 }, new[] { "4", "2", "1" })]

    // 3 elements, descending, one number is divisible by 3 or 5
    [InlineData(new[] { 3, 2, 1 }, new[] { "zzif", "2", "1" })]
    [InlineData(new[] { 5, 3, 1 }, new[] { "zzub", "zzif", "1" })]
    [InlineData(new[] { 15, 5, 1 }, new[] { "zzub zzif", "zzub", "1" })]
    [InlineData(new[] { 15, 5, 3 }, new[] { "zzub zzif", "zzub", "zzif" })]
    public void Tests(int[] numbers, string[] expected)
    {
        var results = FizzBuzz.FizzBuzzIt(numbers);
        results.Should().Equal(expected);
    }
}
