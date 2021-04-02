using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringManipulations
{
    public static class StringManipulations
    {
        /// <summary>
        /// Change case of string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChangeCase(this String str)
        {
            Regex rg = new Regex(@"^[A-Z\s,]*$");
            if (rg.IsMatch(str))
            {
                return str.ToLower();
            }
            else
            {
                return str.ToUpper();
            }
        }

        /// <summary>
        /// Change case of every character in string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChangeCaseOfCharacter(this String str)
        {
            char y;
            var strNew = new StringBuilder();
            foreach (char x in str)
            {
                if (Char.IsUpper(x))
                {
                    y = Char.ToLower(x);
                }
                else
                {
                    y = Char.ToUpper(x);
                }
                strNew.Append(y);
            }
            return strNew.ToString();
        }

        /// <summary>
        /// Change string to title case
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChangeToTitleCase(this String str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            str = textInfo.ToTitleCase(str);
            return str;
        }

        /// <summary>
        /// Check if string is in lower case
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIsLower(this String str)
        {
            Regex rg = new Regex(@"^[a-z\s,]*$");
            if (rg.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if string is in upper case
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIsUpper(this String str)
        {
            Regex rg = new Regex(@"^[A-Z\s,]*$");
            if (rg.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Capitalize the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CapitalizeString(this String str)
        {
            var strNew = new StringBuilder();
            strNew.Append(str);
            strNew[0] = Char.ToUpper(strNew[0]);

            return strNew.ToString();
        }

        /// <summary>
        /// Check if the string is numerical
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIfNumericalString(this String str)
        {
            int n;
            bool isNumeric = int.TryParse(str, out n);

            return isNumeric;
        }

        /// <summary>
        /// Remove last character from string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLastCharacter(this String str)
        {
            str = str.Remove(str.Length - 1);

            return str;
        }

        /// <summary>
        /// Count the words in string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetWordCount(this String str)
        {
            int wordCount = 1, i = 0;
            while (i < str.Length - 1)
            {
                if (str[i] == ' ' || str[i] == '\n' || str[i] == '\t')
                {
                    wordCount++;
                }
                i++;
            }
            return wordCount;
        }

        /// <summary>
        /// Convert string to int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertToIntFromString(this String str)
        {
            int n = 0;
            if (int.TryParse(str, out n))
            {
                n = int.Parse(str);

            }
            return n;
        }
    }
}
