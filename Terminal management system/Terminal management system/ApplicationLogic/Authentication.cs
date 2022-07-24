using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;

namespace Terminal_management_system.ApplicationLogic
{
    class Authentication
    {
        public static Person Register()
        {
            Console.WriteLine();
            Console.WriteLine("write name :");
            string name = Console.ReadLine();

            while (!UserValidations.IsNameValid(name))
            {
                Console.WriteLine("write name again");
                name = Console.ReadLine();
            }

            Console.WriteLine("write surname :");
            string surname = Console.ReadLine();

            while (!UserValidations.IsSurnameValid(surname))
            {
                Console.WriteLine("write surname again");
                surname = Console.ReadLine();
            }

            Console.WriteLine("write email :");
            string email = Console.ReadLine();

            while (!UserValidations.IsEmailValid(email) & UserValidations.isEmailUnical(email))
            {
                Console.WriteLine("write email again");
                email = Console.ReadLine();
            }

            Console.WriteLine("write password :");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password : ");
            string confirmPassword = Console.ReadLine();


            while (!(UserValidations.IsPasswordValid(password) && UserValidations.IsPaswordsMatch(password, confirmPassword)))
            {
                Console.WriteLine("write password again");
                password = Console.ReadLine();

                Console.WriteLine("write confirm password again");
                confirmPassword = Console.ReadLine();
            }

            UserRepository.Add(name, surname, email, password);
            Console.WriteLine("You succesfully registered you can login now with your account");

            Person user = UserRepository.GetUserByEmail(email);

            return user;

        }

        public static void Login()
        {
            Console.WriteLine("Please enter email");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter password");
            string password = Console.ReadLine();

            if (UserValidations.IsLogin(email, password))
            {
                Person user = UserRepository.GetUserByEmail(email);


                if (user is Admin)
                {
                    Dashboard dashBoard = new Dashboard(user);
                    Dashboard.AdminPanel(email);
                }
                else
                {
                    Dashboard.UserPanel(email);
                }

            }
        }
    }
}
