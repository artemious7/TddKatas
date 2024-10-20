namespace ArrayShuffleTddKata;

public class ArrayShuffle(int? seed = null)
{
    private readonly Random random = seed is { } seedValue ? new(seedValue) : new();
    private int GetRandomNumber(int min, int max) => random.Next(min, max);

    public IEnumerable<T> ShuffleArray<T>(IEnumerable<T> input)
    {
        var array = input.ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = GetRandomNumber(0, array.Length);
            (array[randomIndex], array[i]) = (array[i], array[randomIndex]);
        }
        return array;
    }

    public IEnumerable<T> ShuffleIEnumerable<T>(IEnumerable<T> input)
    {
        var list = input.ToList();
        int count = list.Count;
        for (int i = 0; i < count; i++)
        {
            int randomIndex = GetRandomNumber(i, list.Count);
            yield return list[randomIndex];
            list[randomIndex] = list[i];
        }
    }
}