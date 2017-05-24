using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class NegatesForibbenExeption : Exception
    {
    public NegatesForibbenExeption(string message) : base(message)
        {
           
        }
    }
}
