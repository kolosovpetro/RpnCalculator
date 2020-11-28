using System;
using System.Collections.Generic;
using System.Linq;

namespace RpnCalculator.PostfixEvaluator.Implementations
{
    public static class Evaluator
    {
        public static double Evaluate(double value1, double value2, string token)
        {
            return token switch
            {
                "+" => value1 + value2,
                "-" => value1 - value2,
                "*" => value1 * value2,
                "/" => value1 / value2,
                "^" => Math.Pow(value1, value2),
                _ => 0
            };
        }

        public static double Evaluate(double value, string token)
        {
            return token switch
            {
                "sin" => Math.Sin(value),
                "cos" => Math.Cos(value),
                "tan" => Math.Tan(value),
                "ctan" => 1 / Math.Tan(value),
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
                var output = Evaluate(val2, val1, current);
                evaluatorStack.Push(output);
            }

            return evaluatorStack.Pop();
        }
    }
}