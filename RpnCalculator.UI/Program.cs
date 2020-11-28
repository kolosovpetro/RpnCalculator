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
            
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )");
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )");
            Console.WriteLine(postfixExpression); // 1 1 2 / cos + 1 2 / sin +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 2,3570081004945758
            
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard("2 + tan ( 1 / 2 ) + cos ( 0 )");
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix("2 + tan ( 1 / 2 ) + cos ( 0 )");
            Console.WriteLine(postfixExpression); // 2 1 2 / tan + 0 cos +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 3,5463024898437903
        }
    }
}