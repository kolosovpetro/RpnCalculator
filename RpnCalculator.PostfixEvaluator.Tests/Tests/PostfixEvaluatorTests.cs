﻿using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.PostfixEvaluator.Tests.Tests
{
    [TestFixture]
    public class PostfixEvaluatorTests
    {
        [Test]
        public void Evaluator_Operator_Test()
        {
            Evaluator.Evaluate(2, 3, "+").Should().Be(5);
            Evaluator.Evaluate(2, 3, "^").Should().Be(8);
            Evaluator.Evaluate(10, -3, "*").Should().Be(-30);
            Evaluator.Evaluate(10, 5, "/").Should().Be(2);
        }

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

            postfixString = ShuntingYardAlgorithm.InfixToPostfix("20 + 10 ^ 2");
            value = Evaluator.EvaluatePostfix(postfixString);
            value.Should().Be(120);
        }

        [Test]
        public void Postfix_Queue_Evaluator_Test()
        {
            // 3 + 4 * 5 = 23
            var queue = ShuntingYardAlgorithm.ShuntingYard("3 + 4 * 5");
            Evaluator.EvaluatePostfix(queue).Should().Be(23);

            // 3 * (4 + 5) = 27
            queue = ShuntingYardAlgorithm.ShuntingYard("3 * ( 4 + 5 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(27);
        }
    }
}