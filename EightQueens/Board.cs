﻿using FluentAssertions;
using System.Buffers;

namespace EightQueens;

public sealed class Board
{
    private readonly int boardSize;
    private readonly int[][] array;

    public Board(int[][] array, int boardSize)
    {
        this.boardSize = boardSize;
        this.array = CopyBoardArray(array);
    }

    public Board(int boardSize)
    {
        this.boardSize = boardSize;
        array = Enumerable.Range(0, boardSize).Select(r => new int[boardSize]).ToArray();
    }

    public Board? PlaceQueens() => PlaceQueensRecursive(queensLeft: boardSize);

    private Board? PlaceQueensRecursive(int queensLeft, int startRow = 0)
    {
        // no more queens to place - we've got our answer
        if (queensLeft == 0)
        {
            return this;
        }

        if (!HasFreeSpace)
        {
            return null;
        }

        return
            Enumerable.Range(startRow, Height - startRow)
                .Select(PlaceQueenOnRow)
                .FirstOrDefault(board => board is not null);

        Board? PlaceQueenOnRow(int row) =>
            Enumerable.Range(0, Width)
                .Where(column => IsFreeCell(row, column))
                .Select(column => RecursivelyCheckIfQueenCanBeSafelyPlacedInCell(row, column))
                .FirstOrDefault(board => board is not null);

        // try place queen in the cell and recursively check if there are no threats
        Board? RecursivelyCheckIfQueenCanBeSafelyPlacedInCell(int row, int column)
        {
            Board potentialBoard = CopyBoard();
            potentialBoard.PlaceQueen(row, column);

            return potentialBoard.PlaceQueensRecursive(queensLeft - 1, startRow: row + 1);
        }
    }

    private bool HasFreeSpace => Rows.Any(static cellsInRow => cellsInRow.Any(IsFree));

    private IEnumerable<IEnumerable<int>> Rows => array.Select(Row);

    private static IEnumerable<int> Row(int[] row) => row;

    private static bool IsFree(int cellValue) => cellValue == 0;

    private int Width => boardSize;
    private int Height => boardSize;

    private Board CopyBoard() => new(CopyBoardArray(array), boardSize);

    private static int[][] CopyBoardArray(IEnumerable<IEnumerable<int>> array) => array.Select(CopyRow).ToArray();

    private static int[] CopyRow(IEnumerable<int> row) => row.ToArray();

    private bool IsFreeCell(int row, int column)
    {
        if (row >= Height || column >= Width)
        {
            throw new InvalidOperationException($"Row {row} and column {column} are invalid");
        }

        int cellValue = array[row][column];
        return IsFree(cellValue);
    }

    private void PlaceQueen(int queenRow, int queenColumn)
    {
        array[queenRow][queenColumn] = Queen;

        MarkRowsAsThreatOnQueenRow(queenRow);
        MarkColumnsAsThreatOnQueenColumn(queenColumn);
        MarkRightwardDiagonalsAsThreatOnQueenLocation(queenRow, queenColumn);
        MarkLeftwardDiagonalsAsThreatOnQueenLocation(queenRow, queenColumn);

        void MarkLeftwardDiagonalsAsThreatOnQueenLocation(int queenRow, int queenColumn)
        {
            for (int rowOrColumn = 0; rowOrColumn < Width && rowOrColumn < Height; rowOrColumn++)
            {
                int column = queenRow + queenColumn - rowOrColumn;
                if (column < 0 || column >= Width)
                {
                    continue;
                }

                MarkAsThreatIfFree(rowOrColumn, column);
            }
        }

        void MarkRightwardDiagonalsAsThreatOnQueenLocation(int queenRow, int queenColumn)
        {
            int columnOffset = queenColumn - queenRow;
            for (int rowOrColumn = 0; rowOrColumn + columnOffset < Width && rowOrColumn < Height; rowOrColumn++)
            {
                if (rowOrColumn + columnOffset < 0)
                {
                    continue;
                }

                MarkAsThreatIfFree(rowOrColumn, rowOrColumn + columnOffset);
            }
        }

        void MarkColumnsAsThreatOnQueenColumn(int queenColumn)
        {
            for (int row = 0; row < Height; row++)
            {
                MarkAsThreatIfFree(row, queenColumn);
            }
        }

        void MarkRowsAsThreatOnQueenRow(int queenRow)
        {
            for (int column = 0; column < Width; column++)
            {
                MarkAsThreatIfFree(queenRow, column);
            }
        }

        void MarkAsThreatIfFree(int row, int column)
        {
            if (IsFreeCell(row, column))
            {
                array[row][column] = Threat;
            }
        }
    }

    private const int Queen = 1;

    private const int Threat = -1;

    public bool HasNoThreat()
    {
        return Rows.All(SequenceHasNoThreat) &&
            TransposeBoard().All(SequenceHasNoThreat) &&
            RightwardDiagonals().All(SequenceHasNoThreat) &&
            LeftwardDiagonals().All(SequenceHasNoThreat);

        int[][] TransposeBoard()
        {
            int[][] transposedBoard = new int[Height][];

            for (int column = 0; column < Width; column++)
            {
                transposedBoard[column] = new int[Height];
                for (int row = 0; row < Height; row++)
                {
                    transposedBoard[column][row] = array[row][column];
                }
            }
            return transposedBoard;
        }
    }

    internal int[][] RightwardDiagonals()
    {
        var diagonals = new List<int[]>();
        for (int column = 0; column < Width; column++)
        {
            diagonals.Add(GetDiagonal(0, column));
        }

        for (int row = 1; row < Height; row++)
        {
            diagonals.Add(GetDiagonal(row, 0));
        }

        return [.. diagonals];

        int[] GetDiagonal(int rowOffset, int columnOffset)
        {
            var result = new List<int>();
            for (int i = 0; i + rowOffset < Height && i + columnOffset < Width; i++)
            {
                result.Add(array[i + rowOffset][i + columnOffset]);
            }
            return [.. result];
        }
    }

    internal int[][] LeftwardDiagonals()
    {
        Board reversedBoard = new(Rows.Select(row => row.Reverse().ToArray()).ToArray(), boardSize);
        return reversedBoard.RightwardDiagonals();
    }

    private static bool SequenceHasNoThreat(IEnumerable<int> rowOrColumnOrDiagonal) =>
        !rowOrColumnOrDiagonal.Where(IsQueen).Skip(1).Any();

    private static bool IsQueen(int cell) => cell == Queen;

    public int PlacedQueensCount => array.SelectMany(Row).Count(IsQueen);


    #region Printing

    public string Map => Print();

    public override string ToString() => Print().Replace(Environment.NewLine, " | ");

    public string Print()
    {
        return string.Join(Environment.NewLine, Rows.Select(row =>
            string.Join("", row.Select(PrintCell))));

        static string PrintCell(int cell) =>
            !IsQueen(cell)
                ? IsFree(cell)
                    ? "-"
                    : "x"
                : "Q";
    }

    #endregion
}