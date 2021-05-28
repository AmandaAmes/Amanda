using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public static class Strings
    {
        /// <summary>
        /// Implement a string reversal method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse1(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Implement a different string reversal method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse2(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = (input.Length-1); i>=0; i--)
            {
                builder.Append(input[i]);
            }

            return builder.ToString();
        }


        /// <summary>
        /// Implement a string truncation function that safely truncates the input without throwning an exception. Return null if input is null.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SafeTruncate(string input, int length)
        {
            if (string.IsNullOrEmpty(input)) return input;
            if (length <= 0) return "";

            if (input.Length <= length)
                return input;
            else
                return input.Substring(0, length);

        }

        /// <summary>
        /// return a list of even numbers from the input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> EvenNumerics(List<string> input)
        {
            List<int> strResultList = new List<int>();
            int i;
            foreach(string strItem in input)
            {
                if (int.TryParse(strItem, out i))
                {
                    if (i % 2 == 0) strResultList.Add(i);
                }
            }
            return strResultList;
        }
    }
}
