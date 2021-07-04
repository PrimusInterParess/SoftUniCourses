namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;

            }

            Stack<char> openedBrackets = new Stack<char>(parentheses.Length / 2);

            foreach (char item in parentheses)
            {
                char charExpected = default;

                switch (item)
                {
                    case ')':
                        charExpected = '(';
                        break;
                    case ']':
                        charExpected = '[';
                        break;
                    case '}':
                        charExpected = '{';
                        break;
                    default:
                        openedBrackets.Push(item);
                        break;
                }

               

                if (charExpected != default && openedBrackets.Pop() != charExpected)
                {
                    return false;
                }
            }

            return openedBrackets.Count == 0;
        }
    }
}
