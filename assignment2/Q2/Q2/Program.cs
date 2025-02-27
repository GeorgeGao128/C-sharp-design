using System;

namespace Q2;

class Program
{
    private static void Main()
    {
        Console.WriteLine("请输入一串数组，用空格分隔");
        string input = Console.ReadLine();
        string[] strs = input.Split(" ");
        int[] numbers = strs.Select(int.Parse).ToArray();
        int max=numbers[0];
        int min=numbers[0];
        int sum=numbers.Sum();
        int ave=sum/numbers.Length;
        Calculate(ref max,ref min,numbers);
        Console.WriteLine($"数组的最大值为{max}，数组的最小值为{min}，数组的平均值为{ave}，数组的和为{sum}");
    }

    static void Calculate(ref int max,ref int min,int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i]<min)
            {
                min = arr[i];
            }

            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
    }
}
