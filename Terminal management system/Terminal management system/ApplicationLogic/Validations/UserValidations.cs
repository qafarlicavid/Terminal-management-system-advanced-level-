using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;
using Terminal_management_system.Database.Repository.Common;

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

        
        public static bool IsLogin(string email, string password)
        {
            foreach (Person person in UserRepository.DbContext)
            {
                if (person.Email == email && person.Password == password)
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
        public static string GetName()
        {
            Console.Write("write name : ");
            string name = Console.ReadLine();
            while (!UserValidations.IsNameValid(name))
            {
                Console.WriteLine("Please enter correct name : ");
                name = Console.ReadLine();
            }
            return name;
        }
        public static string GetSurname()
        {
            Console.Write("write surname : ");
            string surname = Console.ReadLine();
            while (!UserValidations.IsSurnameValid(surname))
            {
                Console.WriteLine("Please enter correct surname : ");
                surname = Console.ReadLine();
            }
            return surname;
        }

        public static string GetEmail()
        {
            Console.Write("write email : ");
            string email = Console.ReadLine();
            while (!UserValidations.IsEmailValid(email))
            {
                Console.WriteLine("Please enter correct email : ");
                email = Console.ReadLine();
            }
            return email;
        }
        public static string GetPassword()
        {
            Console.WriteLine("write password : ");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password : ");
            string confirmPassword = Console.ReadLine();

            while (!(UserValidations.IsPasswordValid(password) && UserValidations.IsPaswordsMatch(password, confirmPassword)))
            {
                Console.WriteLine("write password again : ");
                password = Console.ReadLine();

                Console.WriteLine("write confirm password again : ");
                confirmPassword = Console.ReadLine();
            }
            return password;
        }
    }
}
