using System.Linq;

namespace RpnCalculator.ShuntingYard.Implementations
{
    public static class Token
    {
        private static readonly string[] Operators = {"^", "*", "/", "+", "-"};
        private static readonly string[] Functions = {"sin", "cos", "tan", "ctan"};

        public static int Precedence(string token)
        {
            return token switch
            {
                "^" => 4,
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

        public static bool IsLeftAssociative(string token)
        {
            return Associativity(token) == "Left";
        }
    }
}