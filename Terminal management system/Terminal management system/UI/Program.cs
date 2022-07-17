using System;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;



namespace Terminal_management_system.UI
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Commands : ");
            Console.WriteLine("/register");
            Console.WriteLine("/login");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();
                    UserValidations.IsValidName(name);

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();
                    UserValidations.IsValidLastname(lastName);

                    Console.Write("Please add person's email code :");
                    string email = Console.ReadLine();
                    UserValidations.IsValidEmail(email);

                    Console.Write("Please add person's password :");
                    string password = Console.ReadLine();
                    UserValidations.IsValidPassword(password);

                    UserRepository.Register(name, lastName, email, password);

                    

                    Console.WriteLine(Person.GetRegisterInfo() + " - Added to system.");
                    Console.WriteLine();
                }
                else if (command == "/login")
                {
                    Console.Write("Please add person's Email :");
                    string email = Console.ReadLine();

                    Console.Write("Please add person's Password :");
                    string password = Console.ReadLine();

                    UserRepository.Login(email, password);

                    Console.WriteLine(Person.GetLoginInfo() + " - Logged to system.");
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
    }
}
