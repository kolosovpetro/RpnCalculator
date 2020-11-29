using FluentAssertions;
using NUnit.Framework;

namespace RpnCalculator.ShuntingYard.Tests.Tests
{
    [TestFixture]
    public class ShuntingYardTests
    {
        [Test]
        public void Infix_To_Postfix_Test()
        {
            var postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("3 + 2 * 4 / 5");
            postfix.Should().Be("3 2 4 * 5 / + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("3 + 4 * 5");
            postfix.Should().Be("3 4 5 * + ");

            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("3 * ( 4 + 5 )");
            postfix.Should().Be("3 4 5 + * ");

            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
            postfix.Should().Be("3 4 2 * 1 5 - 2 3 ^ ^ / + ");

            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("3 - 2 + 1");
            postfix.Should().Be("3 2 - 1 + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("2 * 1 + 2 + sin ( 0 )");
            postfix.Should().Be("2 1 * 2 + 0 sin + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )");
            postfix.Should().Be("1 1 2 / cos + 1 2 / sin + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("2 + tan ( 1 / 2 ) + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan 2 ^ + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )");
            postfix.Should().Be("2 1 2 / tan ln + 0 cos + ");
            
            postfix = ShuntingYardAlgorithm.Implementations.ShuntingYard.InfixToPostfixString("ln ( exp ( 2 ) )");
            postfix.Should().Be("2 exp ln ");
        }
    }
}