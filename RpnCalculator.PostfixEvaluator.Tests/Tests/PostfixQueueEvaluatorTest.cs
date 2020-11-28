using FluentAssertions;
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
        }
    }
}