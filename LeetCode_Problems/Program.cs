using System;
using System.Collections.Generic;

namespace LeetCode_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution to NQueens Problem");

            // MarkNQueens Problem
            int n = 5;

            NQueensProblem problem = new NQueensProblem();
            IList<int[,]> solutions = problem.GetPossibleSolutions(n);

            Console.WriteLine("# of paussible solutions" + solutions.Count);

            int iLoop = 0;
            foreach (int[,] solution in solutions)
            {
                Console.WriteLine("============ {0} ===============", ++iLoop);
                PrintResults(solution, n);
                Console.WriteLine("===========================");
            }

            Console.ReadLine();
        }

        private static void PrintResults(int[,] solution, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(solution[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
