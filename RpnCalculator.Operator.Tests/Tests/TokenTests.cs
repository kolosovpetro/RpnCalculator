using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.Operator.Files;

namespace RpnCalculator.Operator.Tests.Tests
{
    [TestFixture]
    public class TokenTests
    {
        [Test]
        public void Token_Precedence_Test()
        {
            Token.Precedence("^").Should().Be(4);
            Token.Precedence("*").Should().Be(3);
            Token.Precedence("/").Should().Be(3);
            Token.Precedence("+").Should().Be(2);
            Token.Precedence("-").Should().Be(2);
            Token.Precedence("a").Should().Be(0);
        }

        [Test]
        public void Token_Associativity_Test()
        {
            Token.Associativity("^").Should().Be("Right");
            Token.Associativity("*").Should().Be("Left");
            Token.Associativity("/").Should().Be("Left");
            Token.Associativity("+").Should().Be("Left");
            Token.Associativity("-").Should().Be("Left");
        }

        [Test]
        public void Token_Is_Operator_Test()
        {
            Token.IsOperator("a").Should().BeFalse();
            Token.IsOperator("(").Should().BeFalse();
            Token.IsOperator(")").Should().BeFalse();
        }
        
        [Test]
        public void Token_Evaluate_Test()
        {
            Token.Evaluate(2, 3, "+").Should().Be(5);
            Token.Evaluate(2, 3, "^").Should().Be(8);
            Token.Evaluate(10, -3, "*").Should().Be(-30);
            Token.Evaluate(10, 5, "/").Should().Be(2);
        }
    }
}