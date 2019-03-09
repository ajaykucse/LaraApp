using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DLLPrinting
{
    public static class StringExtensions
    {
        public static string MyPadLeft(this string str, int length, char paddingChar)
        {
            return str.PadLeft(length, paddingChar).Substring(0, length);
        }

        public static string MyPadLeft(this string str, int length)
        {
            return str.PadLeft(length).Substring(0, length);
        }

        public static string MyPadRight(this string str, int length, char paddingChar)
        {
            return str.PadRight(length, paddingChar).Substring(0, length);
        }

        public static string MyPadRight(this string str, int length)
        {
            return str.PadRight(length).Substring(0, length);
        }
    }
}
