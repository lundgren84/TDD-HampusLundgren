using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {

           
            int result = 0;
            bool containsNegates = false;
            List<int> negateNumbers = new List<int>();
            List<string> numbers = new List<string>();
            List<char> delimiters = new List<char>() {','};

            if (string.IsNullOrEmpty(input))
                return result;


            var rowStrings = input.Split(Environment.NewLine.ToCharArray());
            var delimiterRegex = GenerateDelimiterRegex(rowStrings[0]);

            if (delimiterRegex.IsMatch(rowStrings[0]))
            {
                //Add delimiter
                delimiters.Add(rowStrings[0][2]);
            }

            // Iterrate all rows and collect numbers
            foreach (var rowString in rowStrings)
            {
                foreach (var delimiter in delimiters)
                {
                    numbers.AddRange(rowString.Split(delimiter));
                }
                var numbersSplittedComma = rowString.Split(',');             
            }


            foreach (var number in numbers)
            {
                int preResult = 0;
                int.TryParse(number, out preResult);


                //Throw NegatesForibbenExeption if number is negative
                if (preResult < 0)
                {
                    containsNegates = true;
                    negateNumbers.Add(preResult);
                }
                else
                {
                    //Ignore Numbers over 1000
                    if (preResult < 1001)
                        result += preResult;
                }



            }
            if (containsNegates)
            {
                var exeptionMessage = "Negative numbers not allowed. : ";
                foreach (var negateNumber in negateNumbers)
                {
                    exeptionMessage += negateNumber + " ";
                }

                throw new NegatesForibbenExeption(exeptionMessage);
            }

            return result;
        }

        private Regex GenerateDelimiterRegex(string input)
        {
          
            var result = new Regex(@"^\/{2}.?$");
            return result;
        }
    }
}
