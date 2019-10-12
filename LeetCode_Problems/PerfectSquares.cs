using System;
using System.Collections.Generic;
using System.Text;


// Problem 279
namespace LeetCodeProblems
{
    class PerfectSquares
    {
        public static int NumSquares(int n)
        {
            if(n == 0)
            {
                return 0;
            }

            int remainingValue = Convert.ToInt32(n - Math.Pow(Math.Truncate(Math.Sqrt(n)), 2));

            return 1 + NumSquares(remainingValue);
        }

        
    }
}
