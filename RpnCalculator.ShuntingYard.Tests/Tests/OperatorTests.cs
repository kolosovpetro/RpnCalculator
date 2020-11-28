using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.ShuntingYard.Tests.Tests
{
    [TestFixture]
    public class OperatorTests
    {
        [Test]
        public void Operator_Precedence_Test()
        {
            Token.Precedence("^").Should().Be(4);
            Token.Precedence("*").Should().Be(3);
            Token.Precedence("/").Should().Be(3);
            Token.Precedence("+").Should().Be(2);
            Token.Precedence("-").Should().Be(2);
            Token.Precedence("a").Should().Be(0);
        }

        [Test]
        public void Operator_Associativity_Test()
        {
            Token.Associativity("^").Should().Be("Right");
            Token.Associativity("*").Should().Be("Left");
            Token.Associativity("/").Should().Be("Left");
            Token.Associativity("+").Should().Be("Left");
            Token.Associativity("-").Should().Be("Left");
        }

        [Test]
        public void Is_Operator_Test()
        {
            Token.IsOperator("a").Should().BeFalse();
            Token.IsOperator("(").Should().BeFalse();
            Token.IsOperator(")").Should().BeFalse();
        }
    }
}