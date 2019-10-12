using System;
using System.Collections.Generic;
using System.Text;

namespace LetterCombinationPhoneNumber
{
    class Solution
    {
        IList<string> letterCombinations = new List<string>();

        public string GetLetters(char digit)
        {
            string letters = "";
            switch (digit)
            {
                case '2': letters = "abc"; break;
                case '3': letters = "def"; break;
                case '4': letters = "ghi"; break;
                case '5': letters = "jkl"; break;
                case '6': letters = "mno"; break;
                case '7': letters = "pqrs"; break;
                case '8': letters = "tuv"; break;
                case '9': letters = "wxyz"; break;
                default: break;
            }

            return letters;
        }
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
                backtrack("", digits);

            return letterCombinations;
        }

        public void backtrack(string combination, string next_digit)
        {
            if(next_digit.Length == 0)
            {
                letterCombinations.Add(combination);
            }
            else
            {
                char digit = next_digit.Substring(0, 1).ToCharArray()[0];
                string letters = GetLetters(digit);

                foreach(char letter in letters)
                {
                    string next_next_digit = next_digit.Substring(1);
                    backtrack(combination + letter, next_next_digit);                    
                }
            }
        }        
    }
}
