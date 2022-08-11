using System;
using Terminal_management_system.ApplicationLogic;
using Terminal_management_system.ApplicationLogic.Services;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;



namespace Terminal_management_system.UI
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------- Welcome --------------------------------------------------------- ");
            Console.WriteLine("Current Commands:");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------- ");

            while (true)
            {
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine("/show-blogs-with-comments");
                Console.WriteLine("/show-filtered-blogs-with-comments");
                Console.WriteLine("/find-blog-by-code");
                Console.WriteLine("/logout");
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
                else if (command == "/show-blogs-with-comments")
                {
                    BlogService.ShowBlogsWithComments();
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    BlogService.FilteredBlogs();
                }
                else if (command == "/find-blog-by-code")
                {
                    BlogService.FindBlogByCode();

                }
                else if (command == "/logout")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command doesn't exist! ");
                }
            }
        }
    }
}
