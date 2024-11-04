using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4
{
    public enum JChar
    {
        DotMark = 46,
        QuestionMark = 63,
        ExclamationMark = 33,
    };

    public static class StringExtension
    {
        public static string AppendChar(this string inputStr, JChar charToAppend)
        {
            return inputStr + Convert.ToChar(charToAppend);
        }
    }
}
