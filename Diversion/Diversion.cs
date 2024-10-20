namespace DiversionTddKata;

public static class Diversion
{
    public static int Answer(int sequenceLength)
    {
        if (sequenceLength == 0) 
            return 1;

        int sum = 0;
        for (int i = 0; i < Math.Pow(2, sequenceLength); i++)
        {
            string binary = Convert.ToString(i, 2);
            if (!binary.Contains("11"))
            {
                sum++;
            }
        }
        return sum;
    }

}