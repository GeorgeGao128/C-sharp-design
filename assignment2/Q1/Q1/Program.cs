using System;
namespace Q1;

class Program
{
    private static void Main()
    {
        Console.WriteLine("请输入一个1000以内的数字");
        int num;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out num)&&num<1000)
                break;
            else
            {
                Console.WriteLine("输入有误，请输入一个1000以内的数字");
            }
        }

        int[] arr=prime(num);
        if (arr[0]==0)
        {
            Console.WriteLine("你输入的数字是质数");
        }
        else
        {
            Console.WriteLine("你输入数字的所有质因数分别是");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    break;
                Console.WriteLine(arr[i]);
            }
        }
    }

    static int[] prime(int n)
    {
        int[] primes = [2, 3, 5, 7, 11, 13, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 
            67, 71, 73, 79, 83, 89, 97,101,103,107,109,113,127,131,137,139,149,151,157,163,
            167,173,179,181,191,193,197,199,211,223,227,229,233,239,241,251,257,263,269,
            271,277,281,283,293,307,311,313,317,331,337,347,349,353,359,367,373,379,383,
            389,397,401,409,419,421,431,433,439,443,449,457,461,463,467,479,487,491,499,
            503,509,521,523,541,547,557,563,569,571,577,587,593,599,601,607,613,617,619,
            631,641,643,647,653,659,661,673,677,683,691,701,709,719,727,733,739,743,751,
            757,761,769,773,787,797,809,811,821,823,827,829,839,853,857,859,863,877,881,
            883,887,907,911,919,929,937,941,947,953,967,971,977,983,991,997];
        int[] result = new int[10000];

    int count = 0;
        for (int i = 0;; i++)
        {
            while (divide( n,primes[i]))
            {
                result[count] = primes[i];
                count++;
                n/=primes[i];
            }
            if (n<primes[i])
                break;
        }
        return result;
    }

    static bool divide(int n, int prime)
    {
        if (n % prime == 0)
            return true;
        else 
            return false;
    }
}