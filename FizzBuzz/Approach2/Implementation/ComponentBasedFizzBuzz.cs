namespace FizzBuzzWithATwist.Approach2.Implementation;

public static class ComponentBasedFizzBuzz
{
    public static string[] FizzBuzzIt(int[] array, IFizzBuzzer fizzBuzzer, IReverser reverser, IOrderingExpert orderingExpert) =>
        orderingExpert.DetermineOrder(array) == Ordering.Descending
            ? array
                .Select(fizzBuzzer.FizzBuzzIt)
                .Select(reverser.Reverse)
                .ToArray()
            : array
                .Select(fizzBuzzer.FizzBuzzIt)
                .ToArray();
}
