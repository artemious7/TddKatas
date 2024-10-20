using System.Collections.Immutable;

namespace AnagramsTddKata;

public static class Anagrams
{
    internal static IEnumerable<string> GenerateAnagrams(string input)
    {
        if (input == "")
        {
            return [""];
        }

        var permutations = IndicesPermutationsOfLength(input.Length);
        return permutations.Select(indicesPermutation => new string(indicesPermutation.Select(i => input[i]).ToArray()));
    }

    private static IEnumerable<IEnumerable<int>> IndicesPermutationsOfLength(int length)
    {
        var range = Enumerable.Range(0, length).ToImmutableList();
        return Permutations(range);

        IEnumerable<ImmutableList<int>> Permutations(ImmutableList<int> input)
        {
            if (input.Count == 1)
            {
                return [input];
            }

            var permutations = input
                .Select(item => (item, permutations: Permutations(input.Remove(item))))
                .SelectMany(r => r.permutations.Select(permutation => permutation.Insert(0, r.item)));
            return permutations;
        }
    }
}