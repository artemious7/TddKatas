namespace BalancedParentheses;

public class BalancedParenthesesTests
{
    [Theory]
    [InlineData("", true)]
    [InlineData("a", true)]
    [InlineData("()", true)]
    [InlineData("(())", true)]
    [InlineData("(", false)]
    [InlineData(")(", false)]
    [InlineData("()()", true)]
    [InlineData("(()())", true)]
    [InlineData("(())())", false)]
    [InlineData("[]", true)]
    [InlineData("[", false)]
    [InlineData("{", false)]
    [InlineData("{}", true)]
    [InlineData("{}{", false)]
    [InlineData("{}{}", true)]
    [InlineData("{{}}", true)]
    [InlineData("{ {)(} }", false)]
    [InlineData("({)}", false)]
    [InlineData("[({})]", true)]
    [InlineData("{ () }[[{}]]", true)]
    public void Tests(string input, bool expected)
    {
        Assert.Equal(expected, BalancedParentheses.IsBalanced(input));
    }
}
