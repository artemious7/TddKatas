namespace FizzBuzzWithATwist.Approach1;

public static class FizzBuzz
{
    public static string[] FizzBuzzIt(int[] array)
    {
        if (array.Length >= 2 && array[0] > array[1])
        {
            return array.Select(r => r % 15 == 0 ?
                "zzub zzif" :
                r % 5 == 0 ?
                    "zzub" :
                    r % 3 == 0 ?
                        "zzif" :
                        r.ToString()
            ).ToArray();
        }
        else
        {
            return array.Select(r => r % 15 == 0 ?
                "fizz buzz" :
                r % 5 == 0 ?
                    "buzz" :
                    r % 3 == 0 ?
                        "fizz" :
                        r.ToString()
            ).ToArray();
        }
    }
}
