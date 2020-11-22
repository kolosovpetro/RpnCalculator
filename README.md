# RPN Calculator

Reverse Polish Notation Calculator. Evaluates infix expressions.

```cs
var postfixString = ShuntingYardAlgorithm.InfixToPostfix("3+4*2/(1-5)^2^3");
Console.WriteLine(postfixString); // 342*15-23^^/+
var value = Evaluator.EvaluatePostfix(postfixString);
Console.WriteLine(value); // 3,0001220703125

postfixString = ShuntingYardAlgorithm.InfixToPostfix("3+4^(1/2)");
Console.WriteLine(postfixString); // 3412/^+
value = Evaluator.EvaluatePostfix(postfixString);
Console.WriteLine(value); // 5
```