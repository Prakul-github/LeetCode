using System;
using System.Collections.Generic;
using System.Text;

namespace CountPrimes
{
    class Solution
    {
        //public static List<int> primeNumbers = new List<int>();
        public int CountPrimes(int n)
        {
            bool[] isPrime = new bool[n];
            int primeNumberCount = 0;

            for (int i = 2; i < n; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i < n; i++)
            {
                if (isPrime[i] == false)
                { continue; }

                for (int j = i * i; j < n; j = j + i)
                {
                    isPrime[j] = false;
                }
            }

            for (int iLoop = 0; iLoop < n; iLoop++)
            {
                if (isPrime[iLoop] == true)
                {
                    primeNumberCount++;
                }
            }
                        
            return primeNumberCount;
        }

    }
}
