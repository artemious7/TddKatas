namespace AnagramsTddKata;

public class AnagramsTests
{
    [Theory]
    [InlineData("", new[] { "" })]
    [InlineData("a", new[] { "a" })]
    [InlineData("ab", new[] { "ab", "ba" })]
    [InlineData("012", new[] { "012", "021", "102", "120", "201", "210" })]
    [InlineData("biro", new[]
    {
        "biro", "bior", "brio", "broi", "boir", "bori",
        "ibro", "ibor", "irbo", "irob", "iobr", "iorb",
        "rbio", "rboi", "ribo", "riob", "roib", "robi",
        "obir", "obri", "oibr", "oirb", "orbi", "orib",
    })]
    public void GenerateAnagramsTests(string input, string[] expected)
    {
        var results = Anagrams.GenerateAnagrams(input);

        Assert.Equal(expected.Order(), results.Order());
    }
}
