namespace FizzBuzzPlus.Implementation;

public static class ComponentBasedFizzBuzzPlus
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
