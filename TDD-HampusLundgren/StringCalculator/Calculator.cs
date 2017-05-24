using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            if (string.IsNullOrEmpty(input))
                return result;


            var numbersSplittedRow = input.Split(Environment.NewLine.ToCharArray());
            List<string> numbers = new List<string>();

            foreach (var numberString in numbersSplittedRow)
            {
                var numbersSplittedComma = numberString.Split(',');
                foreach (var number in numbersSplittedComma)
                {
                    numbers.Add(number);
                }
            }


            foreach (var number in numbers)
            {
                var preResult = Convert.ToInt32(number);


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

    }
}
