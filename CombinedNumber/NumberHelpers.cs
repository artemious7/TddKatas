namespace CombinedNumber;

internal static class NumberHelpers
{
    public static bool IsXYGreaterThanOrEqualToYX(int x, int y)
    {
        return Combine(x, y) >= Combine(y, x);

        static int Combine(int a, int b) => a * (int)Math.Pow(10, PowerOf(b) + 1) + b;
    }

    public static int PowerOf(int x) => x == 0 ? 0 : (int)Math.Floor(Math.Log10(x));
}