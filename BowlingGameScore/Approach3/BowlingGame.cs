#pragma warning disable S3218 // Inner class members should not shadow outer class "static" or type members
#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable S3358 // Ternary operators should not be nested
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BowlingGameScore.Approach3;

public class BowlingGame(object[] input)
{
    public int Calculate()
    {
        FramesCollection framesCollection = new FramesCollection(input);
        return framesCollection.TotalScore;
    }

    public string Print()
    {
        FramesCollection framesCollection = new FramesCollection(input);
        return JsonSerializer.Serialize(framesCollection, new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        });
    }

    private const int FullScore = 10;
    private static bool IsFullScore(int score) => score == FullScore;

    private readonly record struct FramesCollection
    {
        public FramesCollection(object[] input)
        {
            Frames = new(input.Length);
            ConvertToFrames(input);
        }

        public int TotalScore => Frames.OfType<Frame>().Sum(r => r.Score);

        private void ConvertToFrames(object[] input)
        {
            bool bonusThrowsBegan = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] is int[] frameArray && frameArray is [int first, int last])
                {
                    if (bonusThrowsBegan)
                    {
                        throw new ArgumentException("Bonus throws should be at the end", nameof(input));
                    }
                    Frames.Add(new Frame(this, new Throw(first), new Throw(last)));
                }
                else if (input[i] is int throwPins)
                {
                    bonusThrowsBegan = true;
                    Frames.Add(new Throw(throwPins));
                }
                else
                {
                    throw new ArgumentException("Elements should either be int[] with length 2 or int", nameof(input));
                }
            }
        }

        private List<IFrameOrThrow> Frames { get; }

        internal IFrameOrThrow? GetNextFrameAfter(IFrameOrThrow frame) => Frames.ElementAtOrDefault(Frames.IndexOf(frame) + 1);

        internal Throw? GetAfterNextThrow(IFrameOrThrow frame) =>
            GetNextFrameAfter(frame) is { } nextFrame
                ? nextFrame.Has2Throws
                    ? nextFrame.Last
                    : GetNextFrameAfter(nextFrame)?.First
                : null;

        public IFrameOrThrow? GetPreviousFrame(Frame frame) => Frames.ElementAtOrDefault(Frames.IndexOf(frame) - 1);
    }

    private interface IFrameOrThrow
    {
        int Score { get; }
        bool Has2Throws { get; }
        Throw Last { get; }
        Throw First { get; }
        int RunningTotal { get; }
    }

    private sealed class Frame(FramesCollection Frames, Throw First, Throw Last) : IFrameOrThrow
    {
        private int NormalScore => First.Score + Last.Score;
        private int BonusScore =>
            (IsStrike
                ? NextThrow?.Score + AfterNextThrow?.Score
                : IsSpare
                    ? NextThrow?.Score
                    : 0) ?? 0;
        public int Score => NormalScore + BonusScore;
        private bool IsSpare => !First.IsFullScore && IsFullScore(First.Score + Last.Score);
        private bool IsStrike => First.IsFullScore;
        private IFrameOrThrow? NextFrame => Frames.GetNextFrameAfter(this);
        private Throw? NextThrow => NextFrame?.First;
        private Throw? AfterNextThrow => Frames.GetAfterNextThrow(this);
        public bool Has2Throws => !IsStrike;
        public int RunningTotal
        {
            get
            {
                var previousFrameScore = Frames.GetPreviousFrame(this)?.RunningTotal ?? 0;
                return previousFrameScore + Score;
            }
        }

        public Throw First { get; } = First;
        public Throw Last { get; } = Last;
    }


    private record class Throw(int Pins) : IFrameOrThrow
    {
        public virtual int Score => Pins;
        public bool IsFullScore => IsFullScore(Score);
        public bool Has2Throws => false;
        public Throw Last => this;
        public Throw First => this;
        public int RunningTotal => 0;
    }
}
