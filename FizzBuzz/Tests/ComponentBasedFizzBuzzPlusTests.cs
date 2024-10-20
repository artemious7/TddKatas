using FizzBuzzPlus.Implementation;

namespace FizzBuzzPlus.Tests;

public class ComponentBasedFizzBuzzPlusTests
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
    public void Tests(int[] numbers, string[] expected)
    {
        var fizzBuzzer = new FizzBuzzer();
        var reverser = new StringReverser();
        var orderingExpert = new OrderingExpert();
        var results = ComponentBasedFizzBuzzPlus.FizzBuzzIt(numbers, fizzBuzzer, reverser, orderingExpert);
        results.Should().Equal(expected);
    }

    [Theory]
    [InlineData(Ordering.AscendingOrUnknown, new[] { "one", "two" })]
    [InlineData(Ordering.Descending, new[] { "one-reversed", "two-reversed" })]
    public void ReversesIfDescending(Ordering ordering, string[] expected)
    {
        var fizzBuzzer = Substitute.For<IFizzBuzzer>();
        fizzBuzzer.FizzBuzzIt(1).Returns("one");
        fizzBuzzer.FizzBuzzIt(2).Returns("two");

        var reverser = Substitute.For<IReverser>();
        reverser.Reverse("one").Returns("one-reversed");
        reverser.Reverse("two").Returns("two-reversed");

        var orderingExpert = Substitute.For<IOrderingExpert>();
        orderingExpert.DetermineOrder(default!).ReturnsForAnyArgs(ordering);

        var results = ComponentBasedFizzBuzzPlus.FizzBuzzIt([1, 2], fizzBuzzer, reverser, orderingExpert);

        results.Should().Equal(expected);
    }

    [Theory]
    [InlineData(new int[] { }, new string[] { })]
    [InlineData(new int[] { 1 }, new string[] { "1" })]
    [InlineData(new int[] { 1, 2 }, new string[] { "1", "2" })]
    [InlineData(new int[] { 1, 2, 3 }, new string[] { "1", "2", "3" })]
    public void ReturnsArrayWithSameLengthInSameOrderOfElements(int[] numbers, string[] expected)
    {
        var fizzBuzzer = Substitute.For<IFizzBuzzer>();
        // Return the input number as a string
        fizzBuzzer.FizzBuzzIt(default!).ReturnsForAnyArgs(c => c.Arg<int>().ToString());

        var reverser = Substitute.For<IReverser>();
        // Return the input string as is
        reverser.Reverse(default!).ReturnsForAnyArgs(c => c.Arg<string>());

        var orderingExpert = Substitute.For<IOrderingExpert>();
        orderingExpert.DetermineOrder(default!).ReturnsForAnyArgs(Ordering.AscendingOrUnknown);

        var results = ComponentBasedFizzBuzzPlus.FizzBuzzIt(numbers, fizzBuzzer, reverser, orderingExpert);

        results.Should().Equal(expected);
    }
}
