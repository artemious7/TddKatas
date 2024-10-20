using FluentAssertions;
using Xunit.Abstractions;

namespace EightQueensTddKata;

public class EightQueensTests(ITestOutputHelper testOutput)
{
    public static readonly object[][] isNoThreatTestData = [
        // horizontal
        [
            "horizontal 1",
            (int[][])[
                [1, 1, 0],
                [0, 0, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "horizontal 2",
            (int[][])[
                [1, 0, 1],
                [0, 0, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "horizontal 3",
            (int[][])[
                [0, 0, 0],
                [1, 0, 1],
                [0, 0, 0],
            ],
            false
        ],
        [
            "horizontal 4",
            (int[][])[
                [1, 0, 1],
                [0, 0, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "horizontal 5",
            (int[][])[
                [1, 0, 0],
                [0, 0, 0],
                [0, 0, 0],
            ],
            true
        ],
        [
            "horizontal 6",
            (int[][])[
                [0, 0, 0],
                [1, 0, 0],
                [0, 0, 0],
            ],
            true
        ],
        [
            "horizontal 7",
            (int[][])[
                [0, 0, 1],
                [1, 0, 0],
                [0, 0, 0],
            ],
            true
        ],
        [
            "horizontal 8",
            (int[][])[
                [1, 0, 0],
                [0, 0, 1],
                [0, 0, 0],
            ],
            true
        ],

        // vertical
        [
            "vertical 1",
            (int[][])[
                [1, 0, 0],
                [1, 0, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "vertical 2",
            (int[][])[
                [0, 1, 0],
                [0, 1, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "vertical 3",
            (int[][])[
                [0, 1, 0],
                [0, 1, 0],
                [0, 1, 0],
            ],
            false
        ],

        // rightward diagonal
        [
            "rightward diagonal 0,0",
            (int[][])[
                [1, 0, 0],
                [0, 0, 0],
                [0, 0, 1],
            ],
            false
        ],
        [
            "rightward diagonal 1,1",
            (int[][])[
                [0, 0, 0],
                [0, 1, 0],
                [0, 0, 1],
            ],
            false
        ],
        [
            "rightward diagonal 0,2",
            (int[][])[
                [0, 0, 1],
                [0, 0, 0],
                [0, 0, 0],
            ],
            true
        ],
        [
            "rightward diagonal 0,1",
            (int[][])[
                [0, 1, 0],
                [0, 0, 1],
                [0, 0, 0],
            ],
            false
        ],

        // leftward diagonal
        [
            "leftward diagonal 0,1",
            (int[][])[
                [0, 1, 0],
                [1, 0, 0],
                [0, 0, 0],
            ],
            false
        ],
        [
            "leftward diagonal 1,2",
            (int[][])[
                [0, 0, 0],
                [0, 0, 1],
                [0, 1, 0],
            ],
            false
        ],
        [
            "leftward diagonal 0,2",
            (int[][])[
                [0, 0, 1],
                [0, 0, 0],
                [1, 0, 0],
            ],
            false
        ],
    ];

    [Theory]
    [MemberData(nameof(isNoThreatTestData))]
    public void TestIsNoThreat(string description, int[][] boardArray, bool expectedIsNoThreat)
    {
        // Arrange
        using var board = new Board(boardArray, 3, false);

        // Act
        bool isNoThreat = board.IsNoThreat();

        // Assert
        isNoThreat.Should().Be(expectedIsNoThreat, description);
    }

    public static readonly object[][] diagonals = [
        [
            "diagonal 1",
            (int[][])[
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9],
            ],
            (int[][])[
                [1, 5, 9],
                [2, 6],
                [3],
                [4, 8],
                [7]
            ],
            (int[][])[
                [3,5,7],
                [2,4],
                [1],
                [6, 8],
                [9]
            ],
        ],
    ];

    [Theory]
    [MemberData(nameof(diagonals))]
    public void TestDiagonals(string description, int[][] boardArray, int[][] expectedRightwardDiagonals, int[][] expectedLeftwardDiagonals)
    {
        using Board board = new(boardArray, 3, false);
        board.RightwardDiagonals().Should().BeEquivalentTo(expectedRightwardDiagonals, description);
        board.LeftwardDiagonals().Should().BeEquivalentTo(expectedLeftwardDiagonals, description);
    }

    [Theory]
    [InlineData(8)]
    [InlineData(12)]
    //[InlineData(14)]
    //[InlineData(16)]
    //[InlineData(18)]
    public void PlaceQueensTest(int boardSize)
    {
        // Arrange
        using Board board = new(boardSize);

        // Act
        using Board? newBoard = board.PlaceQueens();
        newBoard.Should().NotBeNull();
        testOutput.WriteLine(newBoard!.Print());

        // Assert
        newBoard.IsNoThreat().Should().BeTrue();
        newBoard.QueensCount.Should().Be(boardSize);
    }
}
