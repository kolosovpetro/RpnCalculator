using System.Collections.Generic;
using System.Linq;
using RpnCalculator.Operator.Files;
using RpnCalculator.ShuntingYardAlgorithm.Implementations;

namespace RpnCalculator.Evaluator.Implementations
{
    public static class InfixEvaluator
    {
        public static double EvaluateInfix(Queue<string> postfix)
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
        
        public static double EvaluateInfix(string infixString)
        {
            var resultStack = new Stack<double>();
            var postfixQueue = ShuntingYard.GetPostfixQueue(infixString);

            while (postfixQueue.Any())
            {
                var currentToken = postfixQueue.Dequeue();

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