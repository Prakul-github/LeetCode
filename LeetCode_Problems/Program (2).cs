using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class Program1
    {
        static void Main_old(string[] args)
        {
            //Test_KthSymbol_InGrammar();
            // Test_ReverseString();
            //Test_Prime();

            //Test_LetterCombinationsPhoneNumbers();

            Test_BinarySearchTree();

            //Test_KnapsackProblem();

            //Test_PerectSquares();
        }

        static void Test_PerectSquares()
        {
            int number = 15;
            string arg = "";
            while ((arg = Console.ReadLine()) != "")
            {
                number = Convert.ToInt32(arg);
                Console.WriteLine(" Sum of least prime numbers for " + number + " is : " + PerfectSquares.NumSquares(number));
                Console.WriteLine("Enter the next number to test : ");
            }            
        }

        static void Test_KnapsackProblem()
        {
            DynamicProgramming.KnapsackProblem(new int[] { 1, 3, 4, 5 }, new int[] { 1, 4, 5, 7 }, 7);

            Console.ReadLine();
        }
        static void Test_BinaryTree()
        {
            BinaryTree bTree = new BinaryTree();
            bTree.CreateBinaryTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            StringBuilder result = bTree.PrintBinaryTree();

            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }

        static void Test_BinarySearchTree()
        {
            BinarySearchTree bTree = new BinarySearchTree();
            bTree.CreateBinaryTree(new int[] { 5, 2, 7, 4, 1, 6, 3, 8 });
            StringBuilder result = bTree.PrintBinaryTree();

            Console.WriteLine(result.ToString());
            //Console.ReadLine();

            bTree.DeleteData(7);

            result = bTree.PrintBinaryTree();
            Console.WriteLine(result.ToString());
            Console.ReadLine();

        }

        static void Test_LetterCombinationsPhoneNumbers()
        {
            Console.WriteLine("Letter Combinations Phone Numbers");
            LetterCombinationPhoneNumber.Solution solution = new LetterCombinationPhoneNumber.Solution();
            IList<string> result = solution.LetterCombinations("24");

            foreach(string str in result)
            {
                Console.Write(str + " ");
            }
            //Console.WriteLine(result);

            Console.ReadLine();
        }
        static void Test_Prime()
        {
            Console.WriteLine("Count Primes problem");
            CountPrimes.Solution solution = new CountPrimes.Solution();

            foreach (int num in new int[] { 11, 15, 13, 5, 1000, 10000, 100000, 200000, 300000, 400000, 500000 })
            {
                int result = solution.CountPrimes(num);
                Console.WriteLine();
                Console.WriteLine("Num of Prime Numbers for " + num + " : " + result);                
            }
            Console.ReadLine();
        }

        static void Test_ReverseString()
        {
            string s = "a---bc";
            Console.WriteLine(s);
            string reverse = ReverseString.ReverseOnlyLetters(s);
            Console.WriteLine(reverse);
            Console.ReadLine();
        }

        static void Test_KthSymbol_InGrammar()
        {
            Console.WriteLine("Test_KthSymbol_InGrammar");
            KthSymbol_InGrammar testSolution = new KthSymbol_InGrammar();
            int output = testSolution.KthGrammar(5, 6);

            Console.WriteLine("Output : " + output);

            Console.ReadLine();
        }

        static void Test_NQueensProblem()
        { 
            Console.WriteLine("N Queens problem solution");

            NQUeensProblem solution = new NQUeensProblem();

            int nMatrix = 5;
          //  IList<int[,]> listSolutions = solution.GetPossibleSolutions(nMatrix);

            IList<IList<string>> listSolutions = solution.SolveNQueens(nMatrix);

            Console.WriteLine("NQueen solution for {0} chessboard is {1}", nMatrix, listSolutions.Count);

            int iLoop = 0;

            foreach (List<string> sol in listSolutions)
            {
                Console.WriteLine("============= {0}  ===================", ++iLoop);
                foreach(string str in sol)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("================================");
            }

            Console.ReadLine();
        }
    }
}
