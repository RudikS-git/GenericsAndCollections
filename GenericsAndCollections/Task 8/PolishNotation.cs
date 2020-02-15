using System;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_8
{
    public class PolishNotation
    {
        private enum Operation
        {
            Add,
            Sub,
            Mul,
            Div
        }

        public static double Calc(string str)
        {
            if(str == null)
            {
                throw new ArgumentException("This string is null");
            }

            if(str.Length < 3)
            {
                throw new ArgumentException("Length of the string must be more 3");
            }

            string [] expression = str.Split(' ');

            Stack<double> stackNumbers = new Stack<double>();

            for (int i = 0; i < expression.Length; i++)
            {
                if(double.TryParse(expression[i], out double result))
                {
                    stackNumbers.Push(result);
                }
                else
                {
                    if(i != expression.Length - 1)
                    {
                        stackNumbers.Push(Action(stackNumbers.Pop(), stackNumbers.Pop(), DiscoverOperation(expression[i])));
                    }
                    else
                    {
                        double temp = stackNumbers.Pop();
                        stackNumbers.Push(Action(stackNumbers.Pop(), temp, DiscoverOperation(expression[i])));
                    }
                }
            }

            return stackNumbers.Pop();
        }

        private static double Action(double firstNum, double secondNum, Operation operation)
        {
            switch(operation)
            {
                case Operation.Add:
                    return firstNum + secondNum;
                case Operation.Sub:
                    return firstNum - secondNum;
                case Operation.Mul:
                    return firstNum * secondNum;
                case Operation.Div:
                    return firstNum / secondNum;
                default:
                    throw new ArgumentException("Unknown operation");
            }
            
        }

        private static Operation DiscoverOperation(string operation)
        {
            switch(operation)
            {
                case "+":
                    return Operation.Add;
                case "-":
                    return Operation.Sub;
                case "*":
                    return Operation.Mul;
                case "/":
                    return Operation.Div;
                default:
                    throw new ArgumentException("Unknown operation");
            }
        }

        private static bool IsOperation(string str)
        {
            if(str != "+" && str != "-" && str != "*" && str != "/")
            {
                return false;
            }

            return true;
        }
    }
}
