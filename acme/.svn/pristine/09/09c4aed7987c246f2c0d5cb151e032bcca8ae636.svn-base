using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DLLPrinting
{
    public static class NumberToWord
    {
        public static string ToWords(decimal num)
        {
            string[] s = num.ToString("0.00").Split('.');
            int number = Convert.ToInt32(s[0]);

            string rupees = ToRupees(Convert.ToInt32(s[0]));

            string paisa = "";
            if (Convert.ToInt32(s[1]) > 0)
            {
                paisa = ToPaisa(Convert.ToInt32(s[1]));
            }

            if (string.IsNullOrEmpty(paisa))
            {
                //string ff = rupees + " rupees only";
                return "Rs. " + rupees + " only"; ;
            }
            else
            {
                // string ff = rupees + " rupees and " + paisa + " paisa only";
                return "Rs. " + rupees + " and " + paisa + " paisa only";
            }
        }

        public static string ToPaisa(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ToPaisa(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += ToPaisa(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            //if ((number / 1000000) > 0)
            //{
            //    words += ToPaisa(number / 1000000) + " Ten Lakh ";
            //    number %= 1000000;
            //}

            if ((number / 100000) > 0)
            {
                words += ToPaisa(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += ToPaisa(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ToPaisa(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string ToRupees(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ToRupees(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += ToRupees(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            //if ((number / 1000000) > 0)
            //{
            //    words += ToRupees(number / 1000000) + " Ten Lakh ";
            //    number %= 1000000;
            //}

            if ((number / 100000) > 0)
            {
                words += ToRupees(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += ToRupees(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ToRupees(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        public static string Val(string Value)
        {
            if (Value == "")
                Value = "0";
            return Value;
        }
    }
}
