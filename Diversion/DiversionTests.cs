namespace Diversion;

public class DiversionTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)] // 0, 1                                    
    [InlineData(2, 3)] // 00, 01, 10, 11                          
    [InlineData(3, 5)] // 000, 001, 010, 011, 100, 101, 110, 111      
    [InlineData(4, 8)] // 1111, 1110, 1101, 1100, 0110, 0111, 0011, 1011 ...
    [InlineData(5, 13)] 
    public void Tests(int sequenceLength, int expectedNumbersWithout2AdjacentOnes)
    {
        Assert.Equal(expectedNumbersWithout2AdjacentOnes, Diversion.Answer(sequenceLength));
    }

    [Fact]
    public void LoopTest()
    {
        for (int i = 0; i < 15; i++)
        {
            Assert.Equal(Diversion.Answer(i), Fibonacci(i));
        }
    }

    [Fact]
    public void ConvertTest()
    {
        Assert.Equal("11", Convert.ToString(3, 2));
    }

    private static int Fibonacci(int n) => n == 0 ? 
        1 : 
        n == 1 ? 
            2 : 
            Fibonacci(n - 1) + Fibonacci(n - 2);
}
