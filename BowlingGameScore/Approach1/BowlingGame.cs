using MoreLinq;

#pragma warning disable S3358 // Ternary operators should not be nested
namespace BowlingGameScore.Approach1;

public class BowlingGame
{
    public int Calculate(int[][] input)
    {
        int normalScore = input.Sum(frame => frame.Sum());

        var bonusScores = input
            .ZipLongest(input.Skip(1), (currentFrame, nextFrame) => (currentFrame, nextFrame))
            .ZipLongest(input.Skip(2), (otherFrames, thirdFrame) => (otherFrames.currentFrame, otherFrames.nextFrame, thirdFrame))
            .Select(frames => (currentFrame: Safe(frames.currentFrame), nextFrame: Safe(frames.nextFrame), thirdFrame: Safe(frames.thirdFrame)))
            .Select(frames =>
                IsStrike(frames.currentFrame) ?
                    AddNextTwoThrows(frames) :
                    IsSpare(frames.currentFrame) ?
                        AddNextThrow(frames) :
                        0)
            .Sum();
        return bonusScores + normalScore;

        static bool IsSpare(int[] frame) => frame.Sum() == 10 && !IsStrike(frame);
        static bool IsStrike(int[] frame) => frame[0] == 10;

        int AddNextTwoThrows((int[] currentFrame, int[] nextFrame, int[] thirdFrame) frames) =>
            !IsStrike(frames.nextFrame) ?
                frames.nextFrame.Sum() :
                10 + frames.thirdFrame[0];

        int AddNextThrow((int[] currentFrame, int[] nextFrame, int[] thirdFrame) frames) =>
            frames.nextFrame[0];

        int[] Safe(int[]? frame) => frame ?? [0, 0];
    }
}