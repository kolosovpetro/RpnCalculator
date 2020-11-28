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
            postfix.Should().Be("3 2 - 1 + ");
        }
    }
}