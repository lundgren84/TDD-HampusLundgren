using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngine
{
    public class Validator
    {
        
        private const string emailRegex = @"^([a-zA-Z]+)@([a-zA-Z]+).([a-zA-Z]+)$";

        public bool ValidateEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email)){
                throw new NullOrEmptyExeption();
            }
            return (Regex.IsMatch(email, emailRegex)? true: throw new NotValidEmailExeption(""));
        }

     
    }
}
