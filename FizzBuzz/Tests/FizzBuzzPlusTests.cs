using FizzBuzzPlus.Implementation;

namespace FizzBuzzPlus.Tests;

public class FizzBuzzPlusTests
{
    [Theory]
    [InlineData(new int[] { }, new string[] { })]

    [InlineData(new[] { 1 }, new[] { "1" })]
    [InlineData(new[] { 3 }, new[] { "fizz" })]
    [InlineData(new[] { 5 }, new[] { "buzz" })]
    [InlineData(new[] { 15 }, new[] { "fizz buzz" })]

    [InlineData(new[] { 1, 2 }, new[] { "1", "2" })]
    [InlineData(new[] { 1, 3 }, new[] { "1", "fizz" })]
    [InlineData(new[] { 1, 5 }, new[] { "1", "buzz" })]
    [InlineData(new[] { 1, 15 }, new[] { "1", "fizz buzz" })]

    [InlineData(new[] { 2, 1 }, new[] { "2", "1" })]
    [InlineData(new[] { 3, 1 }, new[] { "zzif", "1" })]
    [InlineData(new[] { 5, 1 }, new[] { "zzub", "1" })]
    [InlineData(new[] { 15, 1 }, new[] { "zzub zzif", "1" })]

    [InlineData(new[] { 2, 1, 0 }, new[] { "2", "1", "zzub zzif" })]
    [InlineData(new[] { 22, 13 }, new[] { "22", "13" })]
    public void SimpleTests(int[] numbers, string[] expected)
    {
        var fizzBuzzer = new FizzBuzzer();
        var reverser = new StringReverser();
        var orderingExpert = new OrderingExpert();
        var results = SimpleFizzBuzz(numbers, fizzBuzzer, reverser, orderingExpert);
        results.Should().Equal(expected);
    }

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

    [Theory]
    [InlineData(Ordering.AscendingOrUnknown, new[] { "one", "two" })]
    [InlineData(Ordering.Descending, new[] { "one-reversed", "two-reversed" })]
    public void SimpleFizzBuzz_ReversesIfDescending(Ordering ordering, string[] expected)
    {
        var fizzBuzzer = Substitute.For<IFizzBuzzer>();
        fizzBuzzer.FizzBuzzIt(1).Returns("one");
        fizzBuzzer.FizzBuzzIt(2).Returns("two");

        var reverser = Substitute.For<IReverser>();
        reverser.Reverse("one").Returns("one-reversed");
        reverser.Reverse("two").Returns("two-reversed");

        var orderingExpert = Substitute.For<IOrderingExpert>();
        orderingExpert.DetermineOrder(default!).ReturnsForAnyArgs(ordering);

        var results = SimpleFizzBuzz([1, 2], fizzBuzzer, reverser, orderingExpert);

        results.Should().Equal(expected);
    }

    [Theory]
    [InlineData(new int[] { }, new string[] { })]
    [InlineData(new int[] { 1 }, new string[] { "1" })]
    [InlineData(new int[] { 1, 2 }, new string[] { "1", "2" })]
    [InlineData(new int[] { 1, 2, 3 }, new string[] { "1", "2", "3" })]
    public void SimpleFizzBuzz_ReturnsArrayWithSameLengthInSameOrderOfElements(int[] numbers, string[] expected)
    {
        var fizzBuzzer = Substitute.For<IFizzBuzzer>();
        // Return the input number as a string
        fizzBuzzer.FizzBuzzIt(default!).ReturnsForAnyArgs(c => c.Arg<int>().ToString());

        var reverser = Substitute.For<IReverser>();
        // Return the input string as is
        reverser.Reverse(default!).ReturnsForAnyArgs(c => c.Arg<string>());

        var orderingExpert = Substitute.For<IOrderingExpert>();
        orderingExpert.DetermineOrder(default!).ReturnsForAnyArgs(Ordering.AscendingOrUnknown);

        var results = SimpleFizzBuzz(numbers, fizzBuzzer, reverser, orderingExpert);

        results.Should().Equal(expected);
    }

    private static string[] SimpleFizzBuzz(int[] array, IFizzBuzzer fizzBuzzer, IReverser reverser, IOrderingExpert orderingExpert)
    {
        var ordering = orderingExpert.DetermineOrder(array);
        if (ordering == Ordering.Descending)
        {
            return array.Select(fizzBuzzer.FizzBuzzIt).Select(reverser.Reverse).ToArray();
        }
        else
        {
            return array.Select(fizzBuzzer.FizzBuzzIt).ToArray();
        }
    }
}
