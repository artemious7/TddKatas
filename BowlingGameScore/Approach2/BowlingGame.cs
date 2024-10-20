using MoreLinq;
using System.Text;

#pragma warning disable S3358 // Ternary operators should not be nested
namespace BowlingGameScore.Approach2;

public static class BowlingGame
{
    public static int Calculate(object[] input)
    {
        var frames = ConvertToFrames(input);
        return frames.Sum(r => r.TotalPoints);
    }

    public static StringBuilder Print(object[] input)
    {
        var sb = new StringBuilder();
        var frames = ConvertToFrames(input);
        int total = 0;
        foreach (var frame in frames)
        {
            total += frame.TotalPoints;
            frame.Print(sb);
            sb.Append('\t').Append(total).AppendLine();
        }
        return sb;
    }

    private static IHaveTotalPoints[] ConvertToFrames(object[] input)
    {
        var frames = new IHaveTotalPoints[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] is int[] frameArray)
            {
                frames[i] = new Frame(frames, i, frameArray[0], frameArray[1]);
            }
            else
            {
                frames[i] = input[i] is int bonusThrowPoints ? 
                    (IHaveTotalPoints)new BonusThrow(bonusThrowPoints) : 
                    throw new InvalidOperationException($"wrong type of input[{i}]");
            }
        }
        return frames;
    }

    private interface IHaveTotalPoints
    {
        int TotalPoints { get; }
        void Print(StringBuilder stringBuilder);
    }

    private sealed record BonusThrow(int FirstThrow) : IHaveTotalPoints
    {
        public void Print(StringBuilder stringBuilder) => stringBuilder.Append(FirstThrow);
        public int TotalPoints => 0;
    }

    private sealed record Frame : IHaveTotalPoints
    {
        private readonly IHaveTotalPoints[] parts;
        private readonly int index;

        public Frame(IHaveTotalPoints[] input, int index, int firstThrow, int secondThrow)
        {
            parts = input;
            this.index = index;
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
        }

        public int FirstThrow { get; }
        public int SecondThrow { get; }

        private bool IsStrike => FirstThrow == 10;

        private bool IsSpare => !IsStrike && FirstThrow + SecondThrow == 10;

        private int NormalPoints => FirstThrow + SecondThrow;
        private int BonusPoints => IsStrike ? NextThrow + ThrowAfterNext : IsSpare ? NextThrow : 0;
        public int TotalPoints => NormalPoints + BonusPoints;

        private IEnumerable<int> NextThrows()
        {
            for (int partIndex = index + 1; partIndex < parts.Length; partIndex++)
            {
                var part = parts[partIndex];
                if (part is Frame { IsStrike: true } strike)
                {
                    yield return strike.NormalPoints;
                }
                else if (part is Frame frame)
                {
                    yield return frame.FirstThrow;
                    yield return frame.SecondThrow;
                }
                else
                {
                    yield return part is BonusThrow bonus ? bonus.FirstThrow : throw new InvalidOperationException();
                }
            }
        }

        public int NextThrow => NextThrows().FirstOrDefault();
        public int ThrowAfterNext => NextThrows().ElementAtOrDefault(1);

        public void Print(StringBuilder stringBuilder) => stringBuilder
            .Append("T1 ")
            .Append(FirstThrow)
            .Append("\tT2 ")
            .Append(SecondThrow)
            .Append("\tNp ")
            .Append(NormalPoints)
            .Append("\tNT ")
            .Append(NextThrow)
            .Append("\tAT ")
            .Append(ThrowAfterNext)
            .Append("\tBp ")
            .Append(BonusPoints)
            .Append("\tTp ")
            .Append(TotalPoints);
    }
}