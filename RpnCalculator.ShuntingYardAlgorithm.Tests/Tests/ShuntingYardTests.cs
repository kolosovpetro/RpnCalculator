using NUnit.Framework;
using RpnCalculator.ShuntingYardAlgorithm.Implementations;

namespace RpnCalculator.ShuntingYardAlgorithm.Tests.Tests
{
    [TestFixture]
    public class ShuntingYardTests
    {
        [TestCase("3 + 2 * 4 / 5", ExpectedResult = "3 2 4 * 5 / + ")]
        [TestCase("3 + 4 * 5", ExpectedResult = "3 4 5 * + ")]
        [TestCase("3 * ( 4 + 5 )", ExpectedResult = "3 4 5 + * ")]
        [TestCase("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", ExpectedResult = "3 4 2 * 1 5 - 2 3 ^ ^ / + ")]
        [TestCase("2 * 1 + 2 + sin ( 0 )", ExpectedResult = "2 1 * 2 + 0 sin + ")]
        [TestCase("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )", ExpectedResult = "1 1 2 / cos + 1 2 / sin + ")]
        [TestCase("2 + tan ( 1 / 2 ) + cos ( 0 )", ExpectedResult = "2 1 2 / tan + 0 cos + ")]
        [TestCase("2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )", ExpectedResult = "2 1 2 / tan 2 ^ + 0 cos + ")]
        [TestCase("2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )", ExpectedResult = "2 1 2 / tan ln + 0 cos + ")]
        [TestCase("ln ( exp ( 2 ) )", ExpectedResult = "2 exp ln ")]
        public string Infix_To_Postfix_String(string infixString)
        {
            return ShuntingYard.InfixToPostfixString(infixString);
        }
    }
}