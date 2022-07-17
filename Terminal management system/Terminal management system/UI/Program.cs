using System;
using Terminal_management_system.ApplicationLogic;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;



namespace Terminal_management_system.UI
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Commands:");

            UserRepository.Add("Super", "Admin", "admin@gmail.com", "123321");

            while (true)
            {
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine();
                string command = Console.ReadLine();
                Console.WriteLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }
                else if (command == "/login")
                {
                    Authentication.Login();
                }
                else
                {
                    Console.WriteLine("Command doesn't exist! ");
                }
            }


        }
    }
}
