using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;
using Terminal_management_system.Database.Repository.Common;
using Terminal_management_system.UI;

namespace Terminal_management_system.ApplicationLogic
{
    public partial class Dashboard : Repository<Person, int>
    {
        public static Person CurrentUser { get; set; }

        public Dashboard(Person currentuser)
        {
            CurrentUser = currentuser;
        }


        public static void AdminPanel(string email)
        {
            UserRepository userRepository = new UserRepository();
            Person user = userRepository.GetUserByEmail(email);
            Console.WriteLine("Admin succesfully joined", user.GetInfo());

            while (true)
            {

                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Commands");

                Console.WriteLine("--User Commands-- : ");
                Console.WriteLine();
                Console.WriteLine("/show-users");
                Console.WriteLine("/remove-user");
                Console.WriteLine("/add-user");
                Console.WriteLine("/update-user");
                Console.WriteLine();
                Console.WriteLine("Admin User's Commands :");
                Console.WriteLine();
                Console.WriteLine("/make-admin");
                Console.WriteLine("/remove-admin");
                Console.WriteLine("/show-admins");
                Console.WriteLine("/add-admin");
                Console.WriteLine("/logout");

                Console.WriteLine($"COMMANDS :  /update-info  /add-user  /show-users  /update-user  /remove-user" +
                    $"   /add-admin  /show-admins  /remove-admin  " +
                    $"   /reports   /all-reports" +
                    $"   /status-blogs  /delete-blog  /delete-all-blogs  /logout");


                Console.WriteLine("Please enter command");
                string command = Console.ReadLine();

                if (command == "/show-users")
                {
                    List<Person> Users = userRepository.GetAll();

                    foreach (Person oneuser in Users)
                    {
                        Console.WriteLine(oneuser.Id + " " + oneuser.FirstName + " " + oneuser.LastName + " " + oneuser.Email);
                    }
                }
                else if (command == "/remove-user")
                {
                    Console.WriteLine("Please Enter email");
                    string targetemail = Console.ReadLine();

                    Person RemoveUser = userRepository.GetUserByEmail(targetemail);
                    if (RemoveUser != null && RemoveUser.Email != RemoveUser.Email)
                    {
                        userRepository.Delete(RemoveUser);
                        Console.WriteLine("User succesfully deleted");

                    }
                    else
                    {
                        Console.WriteLine("Email not found ERROR");
                    }

                }
                else if (command == "/add-user")
                {
                    Authentication.Register();
                    Console.WriteLine("User added");
                }

                else if (command == "/update-user")
                {
                    Console.WriteLine("Please enter user's email");
                    string updateEmail = Console.ReadLine();
                    Person updateUser = userRepository.GetUserByEmail(updateEmail);
                    if (!UserValidations.IsAdmin(updateUser) && !(updateUser.Email == updateUser.Email))
                    {
                        string firstname = Console.ReadLine();
                        string lastname = Console.ReadLine();
                        string mail = Console.ReadLine();
                        string password = Console.ReadLine();
                        Person newUser = userRepository.UpdateInfo(firstname, lastname, mail, password);
                        Console.WriteLine($"{updateUser.FirstName} {updateUser.LastName} succesfully updated to {newUser.FirstName} {newUser.LastName}");

                    }
                    else
                    {
                        Console.WriteLine("Email not found ERROR");
                    }
                }
                else if (command == "/add-admin")
                {
                    Person adminUser = Authentication.Register();
                    userRepository.Delete(adminUser);

                    Admin admin = new Admin(adminUser.FirstName, adminUser.LastName, adminUser.Email, adminUser.Password, adminUser.Id);
                    userRepository.Add(admin);
                    Console.WriteLine($"{adminUser.FirstName} {adminUser.LastName} is the new Admin now");
                }

                else if (command == "/show-admins")
                {
                    Console.WriteLine();
                    Console.WriteLine("Admins : ");
                    UserRepository.ShowAdmins();

                }
                else if (command == "/make-admin")
                {
                    Console.WriteLine("Please enter email");
                    string adminEmail = Console.ReadLine();
                    Person user1 = userRepository.GetUserByEmail(adminEmail);

                    if (user1 is Admin && user1.Email != user1.Email)
                    {
                        Console.WriteLine("You can`t make admin to admin");
                    }
                    else
                    {
                        userRepository.Delete(user1);
                        Admin admin = new Admin(user1.FirstName, user1.LastName, user1.Email, user1.Password, user1.Id);
                        userRepository.Add(admin);
                        Console.WriteLine($"{user1.FirstName} {user1.LastName} is Admin now");

                    }
                }
                else if (command == "/remove-admin")
                {
                    Console.WriteLine("Please enter email");
                    string targetemail = Console.ReadLine();

                    Person adminuser = userRepository.GetUserByEmail(targetemail);
                    if (adminuser is Admin)
                    {

                        userRepository.Delete(adminuser);
                        Console.WriteLine("Admin succesfully deleted");

                    }

                }

                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                }
                else
                {
                    Console.WriteLine("Command Not Found");
                }
            }

        }
        public static void UserPanel()
        {
            UserRepository userRepository = new UserRepository();
            BlogRepository blogRepository = new BlogRepository();
            while (true)
            {
                Console.WriteLine($"/update-info  /report-user  /report  /write-blog  /my-blogs  /logout");
                Console.Write("Enter command : ");
                string command = Console.ReadLine();
                if (command == "/update-info")
                {
                    userRepository.UpdateInfo();
                }
                else if (command == "/logout")
                {
                    Authentication.IsAuthorized = false;
                    break;
                }
                else if (command == "/write-blog")
                {
                    Console.Write("Please enter your blog : ");
                    string content = Console.ReadLine();

                    blogRepository.AddBlog(Authentication.Account, content);
                    Console.WriteLine("blog addded");
                }
                else if (command == "/my-blogs")
                {
                    blogRepository.ShowBlogs();
                }
                else
                {
                    Console.WriteLine("Command not found");
                }
                Console.WriteLine();

            }
        }
    }
}
