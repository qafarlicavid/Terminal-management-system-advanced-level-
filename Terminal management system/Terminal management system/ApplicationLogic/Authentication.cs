using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Repository;

namespace Terminal_management_system.ApplicationLogic
{
    class Authentication
    {
        public static void Register()
        {


            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            Console.Write("What is your surname? ");
            string lastName = Console.ReadLine();
            Console.Write("Okay, please write your email : ");
            string email = Console.ReadLine();
            Console.Write("Then, please write your password : ");
            string password = Console.ReadLine();
            Console.Write("Please confirm your password: ");
            string comfirmPassword = Console.ReadLine();
            Console.WriteLine();


            NameValidation validationName = new NameValidation();
            LastnameValidation validationLastName = new LastnameValidation();
            EmailValidation validationEmail = new EmailValidation();
            PasswordValidation validationPassword = new PasswordValidation();

            if (validationName.IsValid(name) &
                validationLastName.IsValid(lastName) &
                validationEmail.IsEmailValid(email) &
                validationPassword.IsPasswordValid(password) &
                UserRepository.IsEqualConfirmPassword(password, comfirmPassword))
            {
                UserRepository.Add(name, lastName, email, password);

                Console.WriteLine($"{name}, you successfully registered, now you can login with your new account!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You couldn't register!");
                Console.WriteLine();
            }
        }

        public static void Login()
        {
            Console.Write("Input your email: ");
            string email = Console.ReadLine();
            Console.Write("Input your password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            if (UserRepository.IsUserExistsByEmail(email, password))
            {
                Console.WriteLine("Wellcome to our application! ");
            }
            else if (email == "Admin@gmail.com" && password == "123321")
            {
                Console.WriteLine("Welcome Admin!");
                Console.WriteLine("/show-users");
                string command = Console.ReadLine();

                if (command == "/show-users")
                {
                    UserRepository.ShowAllUsers();
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
            else
            {
                Console.WriteLine("Hey, email or password is not correct! ");
            }

            Console.WriteLine();
        }
    }
}
