using System;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.UI
{
    public static class Program
    {
        private static void Main()
        {
            var shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
            var postfixExpression = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");
            Console.WriteLine(postfixExpression); // 3 4 2 * 1 5 - 2 3 ^ ^ / +
            var value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 3,0001220703125

            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard("3 + 4 ^ ( 1 / 2 )");
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix("3 + 4 ^ ( 1 / 2 )");
            Console.WriteLine(postfixExpression); // 3 4 1 2 / ^ +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 5

            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard("10 * ( 10 + 1 ) ^ 2");
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix("10 * ( 10 + 1 ) ^ 2");
            Console.WriteLine(postfixExpression); // 10 10 1 + 2 ^ *
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 1210
        }
    }
}