namespace BalancedParentheses;

public static class BalancedParenthesesImpl
{
    internal static bool IsBalanced(string input)
    {
        Stack<char> stack = [];
        foreach (char character in input)
        {
            if (!TrackBalance('(', ')') ||
                !TrackBalance('[', ']') ||
                !TrackBalance('{', '}'))
            {
                return false;
            }

            bool TrackBalance(char opening, char closing)
            {
                if (character == opening)
                {
                    stack.Push(closing);
                }
                else if (character == closing && !ClosedProperly())
                {
                    return false;
                }

                bool ClosedProperly()
                {
                    return stack.TryPop(out char top) && top == character;
                }

                return true;
            }
        }

        return stack.Count == 0;
    }
}