using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    static class DynamicProgramming
    {
        private static int Max(int firstNumber, int secondNumber)
        {
            return firstNumber > secondNumber ? firstNumber : secondNumber;
        }

        // assuming weights are sorted in increasing order
        public static int KnapsackProblem(int[] weights, int[] values, int MaxWeight)
        {
            int totalItems = weights.Length;
            int maxValue = 0;

            int[,] totalValuesWeights = new int[totalItems + 1, MaxWeight + 1];
            
                      
            for(int jLoop = 0; jLoop < totalItems; jLoop++) // rows
            {
                for (int weight = 0; weight <= MaxWeight; weight++) // columns
                {
                    int itemWeight = weights[jLoop];

                    if (weight == 0 || (jLoop == 0 && itemWeight > weight))
                    {
                        totalValuesWeights[jLoop, weight] = 0;                        
                    }             
                    else if (jLoop == 0 && itemWeight <= weight)
                    {
                        totalValuesWeights[jLoop, weight] = values[jLoop];
                    }
                    else if (itemWeight <= weight)
                    {                        
                        totalValuesWeights[jLoop, weight] = Max(values[jLoop] + totalValuesWeights[jLoop-1, weight - itemWeight], totalValuesWeights[jLoop - 1, weight]);
                    }
                    else
                    {
                        totalValuesWeights[jLoop, weight] = totalValuesWeights[jLoop - 1, weight];
                    }

                    Console.Write(totalValuesWeights[jLoop, weight]);
                }
                Console.WriteLine();
            }

            return maxValue;
        }

        private static void PrintData(int[,] data, int n)
        {
            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    Console.WriteLine(data[row, col]);
                }
            }
        }
    }
}
