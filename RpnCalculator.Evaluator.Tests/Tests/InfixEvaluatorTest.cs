using NUnit.Framework;
using RpnCalculator.Evaluator.Implementations;

namespace RpnCalculator.Evaluator.Tests.Tests
{
    [TestFixture]
    public class InfixEvaluatorTest
    {
        [TestCase("3 + 4 * 5", ExpectedResult = 23)]
        [TestCase("3 * ( 4 + 5 )", ExpectedResult = 27)]
        [TestCase("20 + 30", ExpectedResult = 50)]
        [TestCase("1 + cos ( 1 / 2 ) + sin ( 1 / 2 )", ExpectedResult = 2.3570081004945758)]
        [TestCase("2 + tan ( 1 / 2 ) + cos ( 0 )", ExpectedResult = 3.5463024898437903)]
        [TestCase("2 + ( tan ( 1 / 2 ) ) ^ 2 + cos ( 0 )", ExpectedResult = 3.298446410409525)]
        [TestCase("ln ( exp ( 2 ) )", ExpectedResult = 2)]
        [TestCase("( 2 ^ e ) + 1", ExpectedResult = 7.5808859910179205)]
        [TestCase("( 2 ^ pi ) + 1", ExpectedResult = 9.824977827076287)]
        [TestCase("sin ( pi / 2 )", ExpectedResult = 1)]
        [TestCase("sqrt ( e ^ pi )", ExpectedResult = 4.810477380965351)]
        [TestCase("sin ( pi / 4 )", ExpectedResult = 0.7071067811865476)]
        public double Infix_Evaluator_Test(string infixString)
        {
            return InfixEvaluator.EvaluateInfix(infixString);
        }
    }
}