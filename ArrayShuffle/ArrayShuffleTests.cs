namespace ArrayShuffleTddKata;

public class ArrayShuffleTests
{
    [Fact]
    public void TestShuffleArray()
    {
        ArrayShuffle sut = new(seed: 1);
        int[] input = [1, 2, 3, 4, 5, 6];
        for (int i = 0; i < 200; i++)
        {
            var result = sut.ShuffleArray(input).ToArray();

            Assert.Equal([1, 2, 3, 4, 5, 6], input);
            Assert.NotEqual(input.Order(), result);
            Assert.Equal(input.Order(), result.Order());
        }
    }

    [Fact]
    public void TestShuffleIEnumerable()
    {
        ArrayShuffle sut = new(seed: 2);
        int[] input = [1, 2, 3, 4, 5, 6];
        for (int i = 0; i < 200; i++)
        {
            var result = sut.ShuffleIEnumerable(input).ToArray();

            Assert.Equal([1, 2, 3, 4, 5, 6], input);
            Assert.NotEqual(input.Order(), result);
            Assert.Equal(input.Order(), result.Order());
        }
    }
}
