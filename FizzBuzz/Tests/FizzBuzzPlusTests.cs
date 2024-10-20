using FizzBuzzPlus.Implementation;

namespace FizzBuzzPlus.Tests;

public class FizzBuzzPlusTests
{

    [Theory]
    // zero elements
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

    // 3 elements, descending, numbers only
    [InlineData(new[] { 4, 2, 1 }, new[] { "4", "2", "1" })]

    // 3 elements, descending, one is divisible by 3 or 5
    [InlineData(new[] { 3, 2, 1 }, new[] { "zzif", "2", "1" })]
    [InlineData(new[] { 5, 3, 1 }, new[] { "zzub", "zzif", "1" })]
    [InlineData(new[] { 15, 5, 1 }, new[] { "zzub zzif", "zzub", "1" })]
    [InlineData(new[] { 15, 5, 3 }, new[] { "zzub zzif", "zzub", "zzif" })]
    public void ComplexTests(int[] numbers, string[] expected)
    {
        var results = ComplexFizzBuzz(numbers);
        results.Should().Equal(expected);
    }

    private static string[] ComplexFizzBuzz(int[] array)
    {
        if (array.Length >= 2 && array[0] > array[1])
        {
            return array.Select(r => r % 15 == 0 ? "zzub zzif" : r % 5 == 0 ? "zzub" : r % 3 == 0 ? "zzif" : r.ToString()).ToArray();
        }
        else
        {
            return array.Select(r => r % 15 == 0 ? "fizz buzz" : r % 5 == 0 ? "buzz" : r % 3 == 0 ? "fizz" : r.ToString()).ToArray();
        }
    }

}
