namespace FizzBuzzPlus.Implementation;

public class OrderingExpert : IOrderingExpert
{
    public Ordering DetermineOrder(int[] array) => array.Length >= 2 && array[0] > array[1] ?
        Ordering.Descending :
        Ordering.AscendingOrUnknown;
}
