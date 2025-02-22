// See https://aka.ms/new-console-template for more information

using System;

namespace A1Q1;

class Program
{
    private static void Main()
    {
        int first;
        int second;
        char op;
        double result;

        Console.WriteLine("请输入第一个数字");
        first = getNumber();
        Console.WriteLine("请输入运算符");
        op = getOperator();
        Console.WriteLine("请输入第二个数字");
        second = getNumber();

        switch (op)
        {
            case '+':
               result = first + second;
                break;
            case '-':
                result = first - second;
                break;
            case '*':
                result = first * second;
                break;
            case '/':
                if (second == 0)
                {
                    Console.WriteLine("除数不可以为0");
                    return;
                }
                result = (double)first / second;
                break;
            case '^':
                result = Math.Pow(first, second);
                break;
            case '%':
                result = first % second;
                break;
            default:
                Console.WriteLine("不支持的运算符");
                return;
        }
        Console.WriteLine($"运算的结果是{result}");
    }

    static int getNumber()
    {
        int number;
        while (true)
        {
            if(int.TryParse(Console.ReadLine(), out number))
                return number;
            Console.WriteLine("输入有误，请输入一个数字");
        }
    }
    
    static char getOperator()
    {
        char op;
        while (true)
        {
            if (char.TryParse(Console.ReadLine(), out op))
                return op;
            Console.WriteLine("输入有误，请输入运算符(+ - * / ^ %)");
        }
    }
}