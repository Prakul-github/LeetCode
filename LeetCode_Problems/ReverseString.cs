using System;
using System.Collections.Generic;
using System.Text;


namespace LeetCodeProblems
{
    static class ReverseString
    {
        public static string ReverseOnlyLetters(string S)
        {
            int leftPointer = 0;
            int rightPointer = S.Length - 1;

            string pattern = "[A-Z]|[a-z]";
            System.Text.RegularExpressions.Regex regularExpression = new System.Text.RegularExpressions.Regex(pattern);

            char[] data = S.ToCharArray();

            while(leftPointer < rightPointer)
            {                
                if(regularExpression.IsMatch(data[leftPointer].ToString()) == false)
                {
                    leftPointer++;
                    continue;
                }

                if (regularExpression.IsMatch(data[rightPointer].ToString()) == false)
                {
                    rightPointer--;
                    continue;
                }

                char ch = data[rightPointer];
                data[rightPointer] = data[leftPointer];
                data[leftPointer] = ch;

                leftPointer++;
                rightPointer--;
            }
            return new string(data);
        }
    }
}
