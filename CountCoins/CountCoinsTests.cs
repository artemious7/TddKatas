namespace CountCoinsTddKata;

public class CountCoinsTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 1)]
    [InlineData(5, 2)] // 5 pennies, 1 nickel
    [InlineData(6, 2)] // 6 pennies, 1 pennie + 1 nickel
    [InlineData(7, 2)] // 7 pennies, 2 pennies + 1 nickel
    [InlineData(8, 2)] // 8 pennies, 3 pennies + 1 nickel
    [InlineData(9, 2)] // 9 pennies, 4 pennies + 1 nickel
    [InlineData(10, 4)] // 10 pennies, 5 pennies + 1 nickel, 2 nickels, 1 dime
    [InlineData(11, 4)] // 11 pennies, 6 pennies + 1 nickel, 1 pennie + 2 nickels, 1 pennie + 1 dime
    [InlineData(12, 4)] // 12 pennies, 7 pennies + 1 nickel, 2 pennies + 2 nickels, 2 pennies + 1 dime
    [InlineData(13, 4)] // 12 pennies, 7 pennies + 1 nickel, 2 pennies + 2 nickels, 2 pennies + 1 dime
    [InlineData(14, 4)] // 12 pennies, 7 pennies + 1 nickel, 2 pennies + 2 nickels, 2 pennies + 1 dime
    [InlineData(15, 6)] // 15 pennies, 10 pennies + 1 nickel, 5 pennies + 2 nickels, 5 pennies + 1 dime, 1 nickel + 1 dime, 3 nickels
    [InlineData(25, 6 + 4 + 2 + 1)] // 1x 25, 2x 10, 5x 5
    [InlineData(26, 13)]
    [InlineData(50, 13 * 3 + (6 + 4) * 1)] //          2x 25, 5x 10, 10x 5
    [InlineData(55, 13 * 3 + (6 + 4) * 2 + 1)] //      2x 25, 5x 10, 11x 5
    [InlineData(60, 13 * 4 + (6 + 4) * 2 + 1)] //      2x 25, 6x 10, 12x 5
    [InlineData(65, 13 * 5 + (6 + 4) * 2 + 1 * 2)] //  2x 25, 6x 10, 13x 5
    [InlineData(70, 13 * 6 + (6 + 4) * 2 + 2 * 2 + 1)]
    [InlineData(75, 13 * 7 + (6 + 4) * 2 + (2 * 2 + 1) * 2)]
    [InlineData(80, 13 * 8 + (6 + 4) * 2 + (2 * 2 + 1) * 2 + 1 + 6)]
    [InlineData(99, 213)]
    [InlineData(100, 242)]
    [InlineData(1000, 142511)]
    [InlineData(10_000, 134235101)]
    public void Tests(int amountInCents, int expected)
    {
        const int quarter = 25;
        Assert.Equal(expected, CountCoins.NumberOfWays(amountInCents, quarter));
    }
}
