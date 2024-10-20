namespace CountCoins;

public static class CountCoins
{
    public static int NumberOfWays(int amountInCents, int coinLessThanOrEqual, Dictionary<(int amountInCents, int coinLessThanOrEqual), int>? memo = null)
    {
        memo ??= [];
        if (amountInCents == 0)
        {
            return 1;
        }

        if (amountInCents < 0)
        {
            return 0;
        }

        if (memo.TryGetValue((amountInCents, coinLessThanOrEqual), out int totalNumberOfWays))
        {
            return totalNumberOfWays;
        }

        foreach (var currentCoin in coins.Where(coin => coin <= coinLessThanOrEqual))
        {
            int amountLeft = amountInCents - currentCoin;
            totalNumberOfWays += NumberOfWays(amountLeft, currentCoin, memo);
        }

        memo[(amountInCents, coinLessThanOrEqual)] = totalNumberOfWays;
        return totalNumberOfWays;
    }

    private const int pennie = 1;
    private const int nickel = 5;
    private const int dime = 10;
    private const int quarter = 25;
    private static readonly int[] coins = [quarter, dime, nickel, pennie];
}