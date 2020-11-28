using System;
using System.Collections.Generic;
using System.Linq;
using RpnCalculator.Operator.Files;

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

        private static double Evaluate(double value, string token)
        {
            return token switch
            {
                "sin" => Math.Sin(value),
                "cos" => Math.Cos(value),
                "tan" => Math.Tan(value),
                "ctan" => 1 / Math.Tan(value),
                "sqrt" => Math.Sqrt(value),
                "exp" => Math.Exp(value),
                "ln" => Math.Log(value),
                "log" => Math.Log10(value),
                _ => 0
            };
        }

        public static double Evaluate(string token)
        {
            return token switch
            {
                "e" => Math.E,
                "pi" => Math.PI,
                _ => 0
            };
        }

        public static double EvaluatePostfix(Queue<string> postfix)
        {
            var resultStack = new Stack<double>();

            while (postfix.Any())
            {
                var currentToken = postfix.Dequeue();

                if (Token.IsNumber(currentToken))
                {
                    resultStack.Push(double.Parse(currentToken));
                    continue;
                }

                if (Token.IsOperator(currentToken))
                {
                    var val1 = resultStack.Pop();
                    var val2 = resultStack.Pop();
                    var output = Evaluate(val2, val1, currentToken);
                    resultStack.Push(output);
                    continue;
                }
                
                if (Token.IsFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    var result = Evaluate(value, currentToken);
                    resultStack.Push(result);
                }
            }

            return resultStack.Pop();
        }
    }
}