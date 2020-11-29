using System.Collections.Generic;
using System.Linq;
using RpnCalculator.Operator.Files;
using RpnCalculator.ShuntingYardAlgorithm.Implementations;

namespace RpnCalculator.PostfixEvaluator.Implementations
{
    public static class Evaluator
    {
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
                    var output = Token.Evaluate(val2, val1, currentToken);
                    resultStack.Push(output);
                    continue;
                }
                
                if (Token.IsFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    var result = Token.Evaluate(value, currentToken);
                    resultStack.Push(result);
                }
            }

            return resultStack.Pop();
        }
        
        public static double EvaluatePostfix(string infix)
        {
            var resultStack = new Stack<double>();
            var postfix = ShuntingYard.PostfixQueue(infix);

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
                    var output = Token.Evaluate(val2, val1, currentToken);
                    resultStack.Push(output);
                    continue;
                }
                
                if (Token.IsFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    var result = Token.Evaluate(value, currentToken);
                    resultStack.Push(result);
                }
            }

            return resultStack.Pop();
        }
    }
}