using System;
using System.Linq;

namespace RpnCalculator.ShuntingYard.Implementations
{
    public static class Operator
    {
        private static readonly string[] Operators = {"^", "*", "/", "+", "-"};

        public static int Precedence(string @operator)
        {
            return @operator switch
            {
                "^" => 4,
                "*" => 3,
                "/" => 3,
                "+" => 2,
                "-" => 2,
                _ => 0
            };
        }

        public static string Associativity(string @operator)
        {
            return @operator switch
            {
                "^" => "Right",
                "*" => "Left",
                "/" => "Left",
                "+" => "Left",
                "-" => "Left",
                _ => throw new InvalidOperationException($"Char {@operator} is not an operator")
            };
        }

        public static bool IsOperator(string @operator)
        {
            return Operators.Contains(@operator);
        }
    }
}