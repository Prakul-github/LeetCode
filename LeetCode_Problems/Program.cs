using System;
using System.Collections.Generic;

namespace LeetCode_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            // GraphTheory_AllPathsTraversal(); 
            //GraphTheory_DijkstraAlgo();
            //BellmanFord_ShortestPath();
            GraphTheory_FloydWarshallAlgo();
        }

        static void GraphTheory_FloydWarshallAlgo()
        {
            int[,] graph =  {
                                { 0, 8, 0, 1 },
                                { 0, 0, 1, 0 },
                                { 4, 0, 0, 0 },
                                { 0, 2, 9, 0 }
                            };

            ShortedPathAlgo algo = new ShortedPathAlgo();
            List<int[,]> solutions = algo.FloydWarshall_AllpairsShortestPath(graph, 4);

            Console.WriteLine("FloydWarshall's algo");

            int iLoop = 0;
            foreach(int[,] solution in solutions)
            {
                Console.WriteLine("--- Solution - {0} ---", iLoop++);
                Helper.Print2DArray(solution, 4);
                Console.WriteLine("---");
            }
            
            Console.ReadLine();
        }

        static void BellmanFord_ShortestPath()
        {
            int[,] graph =  {
                                { 0, 0, -1, 0, 0, 0, 0 },
                                { -2, 0, 0, 0, 8, 0, 0 },
                                { 0, 0, 0, 0, 0, 1, 0 },
                                { 0, 9, 1, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 0, -3 },
                                { 0, 0, 0, 6, 0, 0, 2 },
                                { 0, 0, 0, 0, 0, 0, 0 },
                            };

            ShortedPathAlgo algo = new ShortedPathAlgo();
            int[] shortestpath = algo.BellmanFord_ShortestPath(graph, 0, 7);

            Console.WriteLine("Dijksta's algo");
            Helper.PrintArray(shortestpath);
            Console.ReadLine();


        }

        static void GraphTheory_DijkstraAlgo()
        {
            int[,] graph =  {
                            { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                            { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                            { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                            { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                            { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                            { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                            { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                            { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };

            ShortedPathAlgo algo = new ShortedPathAlgo();
            int[] shortestpath = algo.Dijkstra_ShortestPath(graph, 0, 9);

            Console.WriteLine("Dijksta's algo");
            Helper.PrintArray(shortestpath);
            Console.ReadLine();


        }

        static void GraphTheory_AllPathsTraversal()
        {
            Console.WriteLine("Solution to GraphTheory_AllPathsTraversal Problem");

            LeetCode_Problems.GraphTheory.Solution solution = new GraphTheory.Solution();
            IList<IList<int>> solutions = solution.AllPathsSourceTarget(new int[][] { new int[] { 1, 2 }, new int[] { 3 }, new int[] { 3 }, new int[] { } });

            foreach (List<int> s in solutions)
            {
                foreach(int edge in s)
                {
                    Console.Write(edge);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        
        private static void NQueensProblem()
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
                Helper.Print2DArray(solution, n);
                Console.WriteLine("===========================");
            }

            Console.ReadLine();
        }       
    }
}
