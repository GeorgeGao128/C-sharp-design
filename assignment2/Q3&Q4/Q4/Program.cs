using System;
namespace Q3;
using System.Collections.Generic;

class Program
{
    private static void Main()
    { 
        int[,] matrix = new int [3,4]{{1,2,3,4 },{5,1,2,3},{9,5,1,2} };
        Console.WriteLine(IsMatrix(ref matrix));
    }

    static bool IsMatrix(ref int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        return ColsMatrix(ref matrix,cols,rows);
        
    }

    static bool ColsMatrix(ref int[,] matrix, int cols, int rows)
    {
        for (int i = 0 ; i < cols; i++)
        {
            int temp = matrix[0,i];
            for (int j = 0; j < rows; j++)
            {
                if (i + j > rows)
                    break;
                if(matrix[j,j+i] != temp)
                    return false;
            }
        }
        return true;
    }
    
}