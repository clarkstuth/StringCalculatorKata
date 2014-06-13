using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        private List<int> ExtractNumbers(string numbers)
        {
            var delims = ExtractDelimeters(ref numbers);
            var nums = from num in numbers.Split(delims) select int.Parse(num);
            return nums.ToList();
        }

        private char[] ExtractDelimeters(ref string numbers)
        {
            var charList = new List<char>{',','\n'};
            if (numbers.StartsWith("//"))
            {
                var pos = numbers.IndexOf('\n');
                var delim = numbers.Substring(2, 1).ToCharArray()[0];
                charList.Add(delim);
                numbers = numbers.Substring(pos+1);
            }
            return charList.ToArray();
        }

        private void CheckNumbers(List<int> numbers)
        {
            string numberList = "";
            numbers.ForEach((num) =>
            {
                if (num < 0)
                {
                    if (numberList.Length > 0) numberList += ", ";
                    numberList += num.ToString();
                }
            });
            if (numberList.Length > 0)
            {
                throw new NegativesNotAllowedException(String.Format("Negatives Not Allowed: {0}", numberList));
            }
        }

        public int Add(string numbers = "")
        {
            if (String.IsNullOrEmpty(numbers)) return 0;
            var extractedNumbers = ExtractNumbers(numbers);
            CheckNumbers(extractedNumbers);
            return extractedNumbers.Sum();
        }
    }
}
