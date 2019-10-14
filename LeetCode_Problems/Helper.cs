using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Problems
{
    static class Helper
    {
        public static void Print2DArray(int[,] solution, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0} ", solution[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void Copy2DArray(int[,] source, int[,] destination, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    destination[row, col] = source[row, col];
                }                
            }
        }

        public static void MarkNoDirectEdges(int[,] graph, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(graph[row, col] == 0 && row != col)
                    {
                        graph[row, col] = int.MaxValue;
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int iLoop = 0; iLoop < array.Length; iLoop++)
            {
                Console.WriteLine("index {0} value {1}", iLoop, array[iLoop]);
            }
        }
    }
}
