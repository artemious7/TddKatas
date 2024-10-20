namespace BowlingGameScore.Approach2;

public class BowlingGameTests
{
    [Fact]
    public void Given1PinInTheSecondThrowAndTheRestZeros_ThenScoreIs1()
    {
        // Arrange
        int[][] input =
        [
            [ 0,1 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(1);
    }

    [Fact]
    public void GivenFirstFrameWith1Pin_And2PinsInTheSecondFrameAndTheRestZeros_ThenScoreIs3()
    {
        // Arrange
        int[][] input =
        [
            [ 1,0 ],
            [ 2,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
            [ 0,0 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(3);
    }

    [Fact]
    public void Given1PinInEveryThrow_ThenScoreIs20()
    {
        // Arrange
        int[][] input =
        [
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
            [ 1,1 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(20);
    }

    [Fact]
    public void GivenFirstFrameIsSpareAndTheNextThrowIs1_ThenNextThrowIsAddedToTheFirstFrameScore_AndScoreIs12()
    {
        // Arrange
        int[][] input =
        [
            [ 5, 5 ],
            [ 1, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(12);
    }

    [Fact]
    public void GivenFirstFrameIsSpareAndTheNextFrameIs1_1_ThenNextThrowIsAddedToTheFirstFrameScore_AndScoreIs13()
    {
        // Arrange
        int[][] input =
        [
            [ 5, 5 ],
            [ 1, 1 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(13);
    }

    [Fact]
    public void GivenFirstFrameIsStrikeAndTheNextFrameIs1_0_ThenNext2ThrowsAddedToTheFirstFrameScore_AndScoreIs14()
    {
        // Arrange
        int[][] input =
        [
            [ 10, 0 ],
            [ 1, 1 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
            [ 0, 0 ],
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(14);
    }

    [Fact]
    public void NormalThrows_ExceptLastThrows_ThenScoreIs137()
    {
        // Arrange
        int[][] input =
        [
            [ 05, 03 ], // 8
            [ 08, 02 ], // 8 + 2 + 10 = 20 + 8 = 28
            [ 10, 00 ], // 10 + 10 + 1 = 28 + 21 = 49
            [ 10, 00 ], // 10 + 1 + 0 = 49 + 11 = 60
            [ 01, 00 ], // 1 = 61
            [ 09, 01 ], // 9 + 1 + 0 = 71
            [ 00, 10 ], // 10 + 10 = 91
            [ 10, 00 ], // 10 + 6 + 4 = 111
            [ 06, 04 ], // 10 + 7 = 128
            [ 07, 02 ], // 7 + 2 = 137
        ];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(137);
    }

    [Fact]
    public void NormalThrows_ThenScoreIs148()
    {
        // Arrange
        int[][] inputFrames = [
            [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10],[ 10, 0], [6, 4],
            [7, 3]
        ];
        object[] input = [.. inputFrames, 10];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(148);
    }

    [Fact]
    public void PerfectScore_ThenScoreIs300()
    {
        // Arrange
        int[][] inputFrames = [
            [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0],
            [10, 0]
        ];
        object[] input = [.. inputFrames, 10, 10];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(300);
    }

    [Fact]
    public void PerfectScore_OneFrame_ThenScoreIs13()
    {
        // Arrange
        int[][] inputFrames = [
            [10, 0]
        ];
        object[] input = [.. inputFrames, 1, 2];

        // Act
        int score = BowlingGame.Calculate(input);

        // Assert
        score.Should().Be(13);
    }
}
