namespace FizzBuzzPlus.Implementation;

public static class SimpleFizzBuzz
{
    public static string[] FizzBuzzIt(int[] array, IFizzBuzzer fizzBuzzer, IReverser reverser, IOrderingExpert orderingExpert)
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
