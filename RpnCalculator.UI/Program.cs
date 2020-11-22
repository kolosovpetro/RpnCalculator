using System;
using RpnCalculator.PostfixEvaluator.Implementations;
using RpnCalculator.ShuntingYard.Implementation;

namespace RpnCalculator.UI
{
    public static class Program
    {
        private static void Main()
        {
            var postfixString = ShuntingYardAlgorithm.InfixToPostfix("3+4*2/(1-5)^2^3");
            Console.WriteLine(postfixString);    // 342*15-23^^/+
            var value = Evaluator.EvaluatePostfix(postfixString);
            Console.WriteLine(value);    // 3,0001220703125
        }
    }
}