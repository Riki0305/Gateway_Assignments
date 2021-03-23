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

        public static string ChangeToTitleCase(this String str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            str = textInfo.ToTitleCase(str);
            return str;
        }

        public static bool CheckIsLower(this String str)
        {
            Regex rg = new Regex(@"^[a-z\s,]*$");
            if (rg.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIsUpper(this String str)
        {
            Regex rg = new Regex(@"^[A-Z\s,]*$");
            if (rg.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        public static string CapitalizeString(this String str)
        {
            var strNew = new StringBuilder();
            strNew.Append(str);
            strNew[0] = Char.ToUpper(strNew[0]);

            return strNew.ToString();
        }

        public static bool CheckIfNumericalString(this String str)
        {
            int n;
            bool isNumeric = int.TryParse(str, out n);

            return isNumeric;
        }

        public static string RemoveLastCharacter(this String str)
        {
            str = str.Remove(str.Length - 1);

            return str;
        }

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
