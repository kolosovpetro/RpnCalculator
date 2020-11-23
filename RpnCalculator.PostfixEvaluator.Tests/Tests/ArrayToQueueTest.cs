using FluentAssertions;
using NUnit.Framework;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.PostfixEvaluator.Tests.Tests
{
    [TestFixture]
    public class ArrayToQueueTest
    {
        [Test]
        public void Array_To_Queue_Test()
        {
            var queue1 = ShuntingYardAlgorithm.ShuntingYard("10 + 20");
            var postfixString = ShuntingYardAlgorithm.InfixToPostfix("10 + 20");
            var queue2 = Evaluator.ArrayToQueue(postfixString.Split(' '));
            queue1.Dequeue().Should().Be(queue2.Dequeue());
            queue1.Dequeue().Should().Be(queue2.Dequeue());
            queue1.Dequeue().Should().Be(queue2.Dequeue());
        }
    }
}