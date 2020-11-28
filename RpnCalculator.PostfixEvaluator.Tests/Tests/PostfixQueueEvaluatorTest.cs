﻿using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.PostfixEvaluator.Tests.Tests
{
    [TestFixture]
    public class PostfixQueueEvaluatorTest
    {
        [Test]
        public void Postfix_Queue_Evaluator_Test()
        {
            // 3 + 4 * 5 = 23
            var queue = ShuntingYardAlgorithm.ShuntingYard("3 + 4 * 5");
            Evaluator.EvaluatePostfix(queue).Should().Be(23);

            // 3 * (4 + 5) = 27
            queue = ShuntingYardAlgorithm.ShuntingYard("3 * ( 4 + 5 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(27);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("20 + 30");
            Evaluator.EvaluatePostfix(queue).Should().Be(50);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("10 ^ 2");
            Evaluator.EvaluatePostfix(queue).Should().Be(100);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("10 + 10 ^ 2");
            Evaluator.EvaluatePostfix(queue).Should().Be(110);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("10 + ( 10 + 1 ) ^ 2");
            Evaluator.EvaluatePostfix(queue).Should().Be(131);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("10 * ( 10 + 1 ) ^ 2");
            Evaluator.EvaluatePostfix(queue).Should().Be(1210);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(2.3570081004945758);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("2 + tan ( 1 / 2 ) + cos ( 0 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(3.5463024898437903);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(3.298446410409525);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(2.395417554058408);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("ln ( exp ( 2 ) )");
            Evaluator.EvaluatePostfix(queue).Should().Be(2);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("( 2 ^ e ) + 1");
            Evaluator.EvaluatePostfix(queue).Should().Be(7.5808859910179205);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("( 2 ^ pi ) + 1");
            Evaluator.EvaluatePostfix(queue).Should().Be(9.824977827076287);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("sin ( pi / 2 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(1);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("sqrt ( e ^ pi )");
            Evaluator.EvaluatePostfix(queue).Should().Be(4.810477380965351);
            
            queue = ShuntingYardAlgorithm.ShuntingYard("sin ( pi / 4 )");
            Evaluator.EvaluatePostfix(queue).Should().Be(0.7071067811865476);
        }
    }
}