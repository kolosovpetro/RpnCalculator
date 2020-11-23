using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.PostfixEvaluator.Implementations;

namespace RpnCalculator.PostfixEvaluator.Tests.Tests
{
    [TestFixture]
    public class EvaluatorOperatorTest
    {
        [Test]
        public void Evaluator_Operator_Test()
        {
            Evaluator.Evaluate(2, 3, "+").Should().Be(5);
            Evaluator.Evaluate(2, 3, "^").Should().Be(8);
            Evaluator.Evaluate(10, -3, "*").Should().Be(-30);
            Evaluator.Evaluate(10, 5, "/").Should().Be(2);
        }
    }
}