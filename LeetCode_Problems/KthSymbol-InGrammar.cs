/*
 779. K-th Symbol in Grammar
 On the first row, we write a 0. Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.

Given row N and index K, return the K-th indexed symbol in row N. (The values of K are 1-indexed.) (1 indexed).
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class KthSymbol_InGrammar //public class Solution
    {
        public int KthGrammar(int N, int K)
        {
            string Grammar = "0";
            return Convert.ToInt32(BuildGrammar(Grammar, N).Substring(K-1, 1));
        }

        private void ConvertBinaryToDecimal(string binValue)
        {
            Int64 num = Convert.ToInt64(binValue);
            Int64 decVal = 0, baseVal = 1, rem;
            //num = 101;
            //binVal = num;

            while (num > 0)
            {
                rem = num % 10;
                decVal = decVal + rem * baseVal;
                num = num / 10;

                baseVal = baseVal * 2;
            }

            Console.WriteLine("\nDecimal: " + decVal);
        }

        private string BuildGrammar(string Grammar, int N)
        {
            Console.WriteLine(Grammar);
            ConvertBinaryToDecimal(Grammar);
            if (N == 1)
            {                
                return Grammar;
            }
            else
            {
                return BuildGrammar(CreateRow(Grammar), --N);
            }
        }

        private string CreateRow(string previousRow)
        {
            StringBuilder newRow = new StringBuilder();
            foreach(char ch in previousRow)
            {
                switch(ch)
                {
                    case '0':
                        newRow.Append("01");
                        break;
                    default:
                        newRow.Append("10");
                        break;
                }
            }

            return newRow.ToString();
        }
    }
}
