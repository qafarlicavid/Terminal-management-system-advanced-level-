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

        public static bool IsUserExistsByEmail(string email)
        {
            if (!UserRepository.IsEmailExists(email))
            {
                return true;
            }
            Console.WriteLine("Email already exists");
            return false;
        }

        public static string GetName()
        {
            bool isEceptionValid;
            string name = null;
            do
            {

                try
                {
                    Console.Write("Insert Name : ");
                    name = Console.ReadLine();
                    if (name == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Sehvlik var");
                }

            } while (isEceptionValid || !UserValidations.IsNameValid(name));


            return name;
        }
        public static string GetLastName()
        {
            bool isEceptionValid;
            string surname = null;
            do
            {

                try
                {
                    Console.Write("Insert Surname : ");
                    surname = Console.ReadLine();
                    if (surname == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Sehvlik var");
                }

            } while (isEceptionValid || !UserValidations.IsNameValid(surname));


            return surname;
        }

        public static string GetEmail()
        {
            Console.Write("Insert email : ");
            string email = Console.ReadLine();
            while (!UserValidations.IsEmailValid(email) && !UserValidations.IsUserExistsByEmail(email))
            {
                Console.Write("Pls enter email again : ");
                email = Console.ReadLine();
            }
            return email;
        }
        public static string GetPassword()
        {
            string password = null;
            bool isExceptionValid;
            do
            {
                try
                {

                    Console.Write("Insert password : ");
                    password = Console.ReadLine();

                    if (password == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch (Exception)
                {
                    isExceptionValid = true;
                    Console.WriteLine("Xeta var"); ;
                }

            } while (isExceptionValid || !UserValidations.IsPasswordValid(password));

            string confirmPassword = null;
            do
            {
                try
                {

                    Console.Write("Insert password again : ");
                    confirmPassword = Console.ReadLine();
                    if (confirmPassword == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch
                {
                    isExceptionValid = true;
                    Console.WriteLine("Conifrm pass null exception");
                }

            } while (isExceptionValid || !UserValidations.IsPaswordsMatch(password, confirmPassword));


            return password;
        }
        public static string GetTitle()
        {
            Console.Write("enter title : ");
            string title = Console.ReadLine();
            while (!(title.Length >=10 && title.Length <= 25))
            {
                Console.Write("Pls enter title again(min10,max25) : ");
                title = Console.ReadLine();
            }
            return title;
        }
        public static string GetContent()
        {
            Console.Write("enter content : ");
            string content = Console.ReadLine();
            while (!(content.Length >= 20 && content.Length <= 35))
            {
                Console.Write("Pls enter content again(min20,max35) : ");
                content = Console.ReadLine();
            }
            return content;
        }
    }
}
