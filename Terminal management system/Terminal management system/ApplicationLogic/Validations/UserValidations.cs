using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Terminal_management_system.ApplicationLogic.Validations
{
    class UserValidations
    {
        public static bool IsValidName(string name)
        {
            string pattern = "([A-Z][a-z]*)";
            Regex regex = new Regex(pattern);

            if (regex.Match(name).Success)
            {
                return true;
            }

            Console.WriteLine("The name you entered is incorrect," +
                " make sure the name contains only letters," +
                " the first letter is capitalized, and the length is greater than 3 and less than 30. ");

            return false;
        }
        public static bool IsValidLastname(string lastname)
        {
            string pattern = "([A-Z][a-z]*)";
            Regex regex = new Regex(pattern);

            if (regex.Match(lastname).Success)
            {
                return true;
            }

            Console.WriteLine("The lastname you entered is incorrect," +
                " make sure the lastname contains only letters," +
                " the first letter is capitalized, and the length is greater than 3 and less than 30. ");

            return false;
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(pattern);

            if (regex.Match(email).Success)
            {
                return true;
            }

            Console.WriteLine("The email you entered is incorrect, it should contains @ character, and some conditions...");

            return false;
        }
        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            Regex regex = new Regex(pattern);

            if (regex.Match(password).Success)
            {
                return true;
            }

            Console.WriteLine("Password should contain minimum eight characters," +
                " at least one uppercase letter, one lowercase letter and one number:");

            return false;
        }
    }
}
