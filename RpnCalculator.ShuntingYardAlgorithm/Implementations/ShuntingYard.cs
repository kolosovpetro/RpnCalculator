﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpnCalculator.Operator.Files;

namespace RpnCalculator.ShuntingYardAlgorithm.Implementations
{
    public static class ShuntingYard
    {
        public static Queue<string> GetPostfixQueue(string input)
        {
            var outputQueue = new Queue<string>();
            var operandStack = new Stack<string>();
            var inputArray = input.Split(' ');

            foreach (var token in inputArray)
            {
                if (Token.IsNumber(token))
                {
                    outputQueue.Enqueue(token);
                    continue;
                }

                if (Token.IsConstant(token))
                {
                    outputQueue.Enqueue(Token.ReplaceConstant(token));
                    continue;
                }

                if (Token.IsLeftParenthesis(token) || Token.IsFunction(token))
                {
                    operandStack.Push(token);
                    continue;
                }

                if (Token.IsRightParenthesis(token))
                {
                    while (!Token.IsLeftParenthesis(operandStack.Peek()))
                    {
                        outputQueue.Enqueue(operandStack.Pop());
                    }

                    operandStack.Pop();
                    continue;
                }

                while (operandStack.Any() && Token.IsGreaterPrecedence(operandStack.Peek(), token)
                                          && Token.IsLeftAssociated(token))
                {
                    outputQueue.Enqueue(operandStack.Pop());
                }

                operandStack.Push(token);
            }

            while (operandStack.Count > 0)
                outputQueue.Enqueue(operandStack.Pop());

            return outputQueue;
        }

        public static string InfixToPostfixString(string infixString)
        {
            var queue = GetPostfixQueue(infixString);
            var builder = new StringBuilder();

            while (queue.Any())
                builder.Append(queue.Dequeue() + " ");

            return builder.ToString();
        }
    }
}