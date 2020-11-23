using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.PostfixEvaluator.Tests.Tests
{
    [TestFixture]
    public class PostfixStringEvaluatorTest
    {
        [Test]
        public void Postfix_String_Evaluator_Test()
        {
            var postfixString = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 * 5");
            var value = Evaluator.EvaluatePostfix(postfixString);
            value.Should().Be(23);

            postfixString = ShuntingYardAlgorithm.InfixToPostfix("3 * ( 4 + 5 )");
            value = Evaluator.EvaluatePostfix(postfixString);
            value.Should().Be(27);
            
            postfixString = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
            value = Evaluator.EvaluatePostfix(postfixString);
            value.Should().Be(3.0001220703125);

            postfixString = ShuntingYardAlgorithm.InfixToPostfix("10 + 20");
            value = Evaluator.EvaluatePostfix(postfixString);
            value.Should().Be(30);
        }
    }
}