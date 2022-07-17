using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Terminal_management_system.ApplicationLogic.Validations
{
    public class UserValidations
    {
        public virtual bool IsValid(string text)
        {
            string pattern = "^[A-Z][a-z]{2,30}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;
        }

    }
    public class NameValidation : UserValidations
    {

    }
    public class LastnameValidation : UserValidations
    {

    }
    public class EmailValidation
    {
        public bool IsEmailValid(string email)
        {
            string pattern = @"^([a-zA-Z0-9]{2,30})(@code\.edu\.az)$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
    }

    public class PasswordValidation
    {
        public bool IsPasswordValid(string password)
        {
            Regex Number = new Regex(@"[0-9]+");
            Regex UpperChar = new Regex(@"[A-Z]+");
            Regex MiniMaxChars = new Regex(@".{8,}");
            Regex LowerChar = new Regex(@"[a-z]+");


            if (!LowerChar.IsMatch(password))
            {

                return false;
            }
            else if (!UpperChar.IsMatch(password))
            {
                return false;
            }
            else if (!MiniMaxChars.IsMatch(password))
            {
                return false;
            }
            else if (!Number.IsMatch(password))
            {
                return false;
            }

            return true;
        }


    }
}
