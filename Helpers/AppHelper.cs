using System;
using System.Text.RegularExpressions;
namespace Rentless
{
    public class AppHelper
    {
        public static string CustSequence = "C00000001";
        public static string getNextCustId()
        {
            string newString = Regex.Replace(CustSequence, "\\d+",  m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
            return newString;
        }
    }
}