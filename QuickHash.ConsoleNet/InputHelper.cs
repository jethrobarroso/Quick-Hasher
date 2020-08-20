using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickHash.ConsoleNet
{
    public static class InputHelper
    {
        public static bool ValidateDate(string input)
        {
            string pattern = @"^\d{4}-((0[1-9])|1[12])-((0[0-9])|(1[0-9])|(2[0-9])|(3[01]))$";
            bool result = Regex.IsMatch(input, pattern);

            return result;
        }

        public static string StripHyphens(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return input.Replace("-", string.Empty);
            return input;
        }
    }
}
