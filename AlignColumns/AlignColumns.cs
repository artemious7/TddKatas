public class AlignColumns
{
    const string delineator = "  ";

    public static string Align(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var table = lines.Select(ToCells).ToArray();
        int maxColumnsCount = table.Max(line => line.Length);

        (..maxColumnsCount).ForEach(ProcessColumn);

        return string.Join(Environment.NewLine, table.Select(JoinCells));

        void ProcessColumn(int column)
        {
            int longestLength = MaxLengthOfColumn();
            table.ForEach(PadCell);

            int MaxLengthOfColumn()
            {
                var cells = table.Select(row => row.ElementAtOrDefault(column));
                return cells.Max(cell => cell?.Length ?? 0);
            }

            void PadCell(string[] row)
            {
                if (row.Length > column)
                {
                    row[column] = row[column].PadRight(longestLength);
                }
            }
        }

        static string[] ToCells(string line) =>
            line.Split('$', StringSplitOptions.RemoveEmptyEntries);

        static string JoinCells(string[] cells) =>
            string.Join(delineator, cells).Trim();
    }
}
