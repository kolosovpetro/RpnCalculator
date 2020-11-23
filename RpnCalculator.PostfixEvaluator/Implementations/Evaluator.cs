using System;
using System.Collections.Generic;
using System.Linq;

namespace RpnCalculator.PostfixEvaluator.Implementations
{
    public static class Evaluator
    {
        public static double Evaluate(double value1, double value2, string @operator)
        {
            return @operator switch
            {
                "+" => value1 + value2,
                "-" => value1 - value2,
                "*" => value1 * value2,
                "/" => value1 / value2,
                "^" => Math.Pow(value1, value2),
                _ => 0
            };
        }

        public static double EvaluatePostfix(Queue<string> postfix)
        {
            var evaluatorStack = new Stack<double>();

            while (postfix.Any())
            {
                var current = postfix.Dequeue();

                if (double.TryParse(current, out var number))
                {
                    evaluatorStack.Push(number);
                    continue;
                }

                var val1 = evaluatorStack.Pop();
                var val2 = evaluatorStack.Pop();
                var output = Evaluate(val1, val2, current);
                evaluatorStack.Push(output);
            }

            return evaluatorStack.Pop();
        }

        public static double EvaluatePostfix(string str)
        {
            var evaluatorStack = new Stack<double>();
            var split = str.Split(' ');
            var postfixQueue = ArrayToQueue(split);

            while (postfixQueue.Any())
            {
                var current = postfixQueue.Dequeue();

                if (double.TryParse(current, out var number))
                {
                    evaluatorStack.Push(number);
                    continue;
                }

                var val1 = evaluatorStack.Pop();
                var val2 = evaluatorStack.Pop();
                var output = Evaluate(val2, val1, current);
                evaluatorStack.Push(output);
            }

            return evaluatorStack.Pop();
        }

        public static Queue<string> ArrayToQueue(IEnumerable<string> arr)
        {
            var queue = new Queue<string>();

            foreach (var str in arr)
            {
                queue.Enqueue(str);
            }

            return queue;
        }
    }
}