using System;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementations;

namespace RpnCalculator.UI
{
    public static class Program
    {
        private static void Main()
        {
            var infixString = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
            var shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            var postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 3 4 2 * 1 5 - 2 3 ^ ^ / +
            var value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 3,0001220703125

            infixString = "3 + 4 ^ ( 1 / 2 )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 3 4 1 2 / ^ +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 5

            infixString = "10 * ( 10 + 1 ) ^ 2";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 10 10 1 + 2 ^ *
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 1210

            infixString = "1 + cos ( 1 / 2 ) + sin ( 1 / 2 )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 1 1 2 / cos + 1 2 / sin +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 2,3570081004945758

            infixString = "2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 2 1 2 / tan 2 ^ + 0 cos +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 3,298446410409525
            
            infixString = "2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 2 1 2 / tan ln + 0 cos +
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 2,395417554058408
            
            infixString = "ln ( exp ( 2 ) )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 2 exp ln
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 2
            
            infixString = "sqrt ( e ^ pi )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 2,718281828459045 3,141592653589793 ^ sqrt
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 4,810477380965351
            
            infixString = "sin ( pi / 4 )";
            shuntingYardQueue = ShuntingYardAlgorithm.ShuntingYard(infixString);
            postfixExpression = ShuntingYardAlgorithm.InfixToPostfix(infixString);
            Console.WriteLine(postfixExpression); // 3,141592653589793 4 / sin
            value = Evaluator.EvaluatePostfix(shuntingYardQueue);
            Console.WriteLine(value); // 0,7071067811865476
        }
    }
}