﻿using System.Linq;

namespace RpnCalculator.Operator.Files
{
    public static class Token
    {
        private static readonly string[] Operators = {"^", "*", "/", "+", "-"};
        private static readonly string[] Functions = {"sin", "cos", "tan", "ctan", "sqrt", "exp", "ln", "log"};
        private static readonly string[] Constants = {"e", "pi"};

        public static int Precedence(string token)
        {
            return token switch
            {
                "^" => 4,
                "sin" => 4,
                "cos" => 4,
                "tan" => 4,
                "ctan" => 4,
                "sqrt" => 4,
                "exp" => 4,
                "ln" => 4,
                "log" => 4,
                "*" => 3,
                "/" => 3,
                "+" => 2,
                "-" => 2,
                _ => 0
            };
        }

        public static string Associativity(string token)
        {
            return token == "^" ? "Right" : "Left";
        }

        public static bool IsOperator(string token)
        {
            return Operators.Contains(token);
        }

        public static bool IsFunction(string token)
        {
            return Functions.Contains(token);
        }

        public static bool IsNumber(string token)
        {
            return double.TryParse(token, out _);
        }

        public static bool IsLeftParenthesis(string token)
        {
            return token == "(";
        }

        public static bool IsRightParenthesis(string token)
        {
            return token == ")";
        }

        public static bool IsLeftAssociated(string token)
        {
            return Associativity(token) == "Left";
        }

        public static bool IsGreaterPrecedence(string token1, string token2)
        {
            return Precedence(token1) >= Precedence(token2);
        }

        public static bool IsConstant(string token)
        {
            return Constants.Contains(token);
        }
    }
}