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
        public static Person Account { get; set; }
        public static bool IsAuthorized { get; set; } = false;

        public static Person Register()
        {
            UserRepository userRepository = new UserRepository();

            Console.WriteLine();
            string name = UserValidations.GetName();
            string surname = UserValidations.GetLastName();
            string email = UserValidations.GetEmail();
            string password = UserValidations.GetPassword();

            userRepository.AddUser(name, surname, email, password);
            Console.WriteLine("You succesfully registered you can login now with your account");

            Person user = userRepository.GetUserByEmail(email);

            return user;
        }
        public static void Login()
        {
            UserRepository userRepository = new UserRepository();

            Console.WriteLine("Please enter email");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter password");
            string password = Console.ReadLine();

            if (UserValidations.IsLogin(email, password))
            {
                Person user = userRepository.GetUserByEmail(email);

                if (user is Admin)
                {
                    Dashboard.AdminPanel(email);
                }
                else
                {
                    Dashboard.UserPanel();
                }
            }
        }
    }
}
