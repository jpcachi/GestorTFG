using System;
using System.Globalization;

namespace GestorTFG
{
    public static class StringExtension
    {
        public static bool Contiene(this string baseString, string textToSearch, StringComparison comparisonMode)
        {
            return (baseString.IndexOf(textToSearch, comparisonMode) != -1);
        }

        public static bool Contiene(this string baseString, string textToSearch)
        {
            CompareInfo compareInfo = new CultureInfo("en-US").CompareInfo;
            CompareOptions compareOptions = CompareOptions.IgnoreCase;
            return (compareInfo.IndexOf(baseString, textToSearch, compareOptions) != -1);
        }
    }
}
