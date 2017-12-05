using System;
using System.Collections.Generic;

namespace CalculatorLogic
{
    public static class Calculator
    {
 
        public static double Calculate(string expression)
        {
            char operation = expression[expression.IndexOfAny(new[] {'+', '-', '/', '*'})];
            string[] arguments = expression.Split(operation);
            double a = double.Parse(arguments[0].Trim());
            double b = double.Parse(arguments[1].Trim());

            switch (operation)
            {
                case '+':
                    return Add(a, b);
                case '-':
                    return Add(a, -b);
                case '*':
                    return Multiplication(a, b);
                case '/':
                    return Multiplication(a, 1/b);
                default:
                    throw new ArgumentException("Operation doesn't supported");
            }
        }

        private static double Add(double a, double b) => a + b;

        private static double Multiplication(double a, double b) => a * b;
    }
}