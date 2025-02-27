using System;
namespace Q3;
using System.Collections.Generic;

class Program
{
    private static void Main()
    {
        List<int> numbers = new List<int>() ;
        for (int i = 2; i < 100; i++)
        {
            numbers.Add(i);
        }
        SieveOfEratosthenes(ref numbers);
        Console.WriteLine("一百以内的质数为");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }


    static List<int> SieveOfEratosthenes(ref List<int> numbers)
    {
        int[] primes =
        {
            2, 3, 5, 7, 11, 13, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61,
            67, 71, 73, 79, 83, 89, 97
        };
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < primes.Length; j++)
            {
                if (primes[j] >= numbers[i])
                {
                    break;
                }
                if (numbers[i] % primes[j] == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                    break;
                }
            }
        }
        return numbers;
    }
}