using System;
using RpnCalculator.Evaluator.Implementations;
using RpnCalculator.ShuntingYardAlgorithm.Implementations;

namespace RpnCalculator.UI
{
    public static class Program
    {
        private static void Main()
        {
            var infixString = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 3 4 2 * 1 5 - 2 3 ^ ^ / +
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 3,0001220703125
            
            infixString = "3 + 4 ^ ( 1 / 2 )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 3 4 1 2 / ^ +
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 5

            infixString = "10 * ( 10 + 1 ) ^ 2";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 10 10 1 + 2 ^ *
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 1210

            infixString = "1 + cos ( 1 / 2 ) + sin ( 1 / 2 )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 1 1 2 / cos + 1 2 / sin +
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 2,3570081004945758

            infixString = "2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 2 1 2 / tan 2 ^ + 0 cos +
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 3,298446410409525
            
            infixString = "2 + ln ( tan ( 1 / 2 ) ) + cos ( 0 )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 2 1 2 / tan ln + 0 cos +
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 2,395417554058408
            
            infixString = "ln ( exp ( 2 ) )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 2 exp ln
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 2
            
            infixString = "sqrt ( e ^ pi )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 2,718281828459045 3,141592653589793 ^ sqrt
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 4,810477380965351
            
            infixString = "sin ( pi / 4 )";
            Console.WriteLine(ShuntingYard.InfixToPostfixString(infixString));    // 3,141592653589793 4 / sin
            Console.WriteLine(InfixEvaluator.EvaluateInfix(infixString));    // 0,7071067811865476
        }
    }
}