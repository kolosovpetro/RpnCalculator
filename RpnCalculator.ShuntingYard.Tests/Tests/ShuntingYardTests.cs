using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.ShuntingYard.Implementation;

namespace RpnCalculator.ShuntingYard.Tests.Tests
{
    [TestFixture]
    public class ShuntingYardTests
    {
        [Test]
        public void Infix_To_Postfix_Test()
        {
            var postfix = ShuntingYardAlgorithm.InfixToPostfix("3+2*4/5");
            postfix.Should().Be("324*5/+");
            
            postfix = ShuntingYardAlgorithm.InfixToPostfix("3+4*5");
            postfix.Should().Be("345*+");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3*(4+5)");
            postfix.Should().Be("345+*");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3+4*2/(1-5)^2^3");
            postfix.Should().Be("342*15-23^^/+");

            postfix = ShuntingYardAlgorithm.InfixToPostfix("3-2+1");
            postfix.Should().Be("32-1+");
        }
    }
}