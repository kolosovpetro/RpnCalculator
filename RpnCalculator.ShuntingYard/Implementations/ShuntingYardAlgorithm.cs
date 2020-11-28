using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpnCalculator.ShuntingYard.Implementations
{
    public static class ShuntingYardAlgorithm
    {
        public static Queue<string> ShuntingYard(string input)
        {
            var outputQueue = new Queue<string>();
            var operandStack = new Stack<string>();
            var inputArray = input.Split(' ');

            foreach (var token in inputArray)
            {
                if (double.TryParse(token, out _))
                {
                    outputQueue.Enqueue(token);
                    continue;
                }

                switch (token)
                {
                    case "(":
                        operandStack.Push(token);
                        continue;
                    case ")":
                    {
                        while (operandStack.Peek() != "(")
                            outputQueue.Enqueue(operandStack.Pop());
                        operandStack.Pop();
                        continue;
                    }
                }

                while (operandStack.Count > 0
                       && Token.Precedence(operandStack.Peek()) >= Token.Precedence(token)
                       && Token.Associativity(token) == "Left")
                {
                    outputQueue.Enqueue(operandStack.Pop());
                }

                operandStack.Push(token);
            }

            while (operandStack.Any())
                outputQueue.Enqueue(operandStack.Pop());
            
            return outputQueue;
        }

        public static string InfixToPostfix(string infix)
        {
            var queue = ShuntingYard(infix);
            var builder = new StringBuilder();

            while (queue.Any())
                builder.Append(queue.Dequeue() + " ");

            return builder.ToString();
        }
    }
}