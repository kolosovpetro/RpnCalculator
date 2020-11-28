using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.ShuntingYard.Tests.Tests
{
    [TestFixture]
    public class ShuntingYardTests
    {
        [Test]
        public void Infix_To_Postfix_Test()
        {
            var postfix = ShuntingYardAlgorithm.InfixToPostfix("3 + 2 * 4 / 5");
            postfix.Should().Be("3 2 4 * 5 / + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 * 5");
            postfix.Should().Be("3 4 5 * + ");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3 * ( 4 + 5 )");
            postfix.Should().Be("3 4 5 + * ");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
            postfix.Should().Be("3 4 2 * 1 5 - 2 3 ^ ^ / + ");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3 - 2 + 1");
            postfix.Should().Be("3 2 - 1 + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("2 * 1 + 2 + sin ( 0 )");
            postfix.Should().Be("2 1 * 2 + 0 sin + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )");
            postfix.Should().Be("1 1 2 / cos + 1 2 / sin + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("2 + tan ( 1 / 2 ) + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan 2 ^ + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan ln + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("ln ( exp ( 2 ) )");
            postfix.Should().Be("2 exp ln ");
        }
    }
}