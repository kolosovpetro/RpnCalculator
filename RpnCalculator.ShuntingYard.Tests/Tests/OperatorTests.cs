using System;
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
            Operator.Precedence("^").Should().Be(4);
            Operator.Precedence("*").Should().Be(3);
            Operator.Precedence("/").Should().Be(3);
            Operator.Precedence("+").Should().Be(2);
            Operator.Precedence("-").Should().Be(2);
            Operator.Precedence("a").Should().Be(0);
        }

        [Test]
        public void Operator_Associativity_Test()
        {
            Operator.Associativity("^").Should().Be("Right");
            Operator.Associativity("*").Should().Be("Left");
            Operator.Associativity("/").Should().Be("Left");
            Operator.Associativity("+").Should().Be("Left");
            Operator.Associativity("-").Should().Be("Left");

            Action act = () => Operator.Associativity("a");
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Char a is not an operator");
        }

        [Test]
        public void Is_Operator_Test()
        {
            Operator.IsOperator("a").Should().BeFalse();
            Operator.IsOperator("(").Should().BeFalse();
            Operator.IsOperator(")").Should().BeFalse();
        }
    }
}