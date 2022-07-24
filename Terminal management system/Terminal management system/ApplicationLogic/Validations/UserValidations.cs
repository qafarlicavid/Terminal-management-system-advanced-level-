using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;

namespace Terminal_management_system.ApplicationLogic.Validations
{
    public class UserValidations
    {
        public static bool IsNameValid(string name)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{2,30}");

            return regex.IsMatch(name);
        }

        public static bool IsSurnameValid(string surname)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{2,30}");

            return regex.IsMatch(surname);
        }

        public static bool IsEmailValid(string email)
        {
            Regex regex = new Regex("^[a-z]+[@]+[code]+[.]+[edu]+[.]+[az]+$");

            return regex.IsMatch(email);
        }

        public static bool IsPasswordValid(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");

            return regex.IsMatch(password);
        }

        public static bool IsPaswordsMatch(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        public static bool isEmailUnical(string email)
        {
            foreach (Person person in UserRepository.Persons)
            {
                if (Person.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsLogin(string email, string password)
        {
            foreach (Person person in UserRepository.Persons)
            {
                if (Person.Email == email && Person.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("ERROR! False info!");
            return false;

        }

        public static bool IsAdmin(Person person)
        {
            if (person is Admin)
            {
                Console.WriteLine("User is Admin");
                return true;
            }
            return false;
        }

    }
}
