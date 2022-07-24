using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository;
using Terminal_management_system.UI;

namespace Terminal_management_system.ApplicationLogic
{
    class Dashboard
    {
        public static Person CurrentUser { get; set; }

        public Dashboard(Person currentuser)
        {
            CurrentUser = currentuser;
        }


        public static void AdminPanel(string email)
        {

            Person user = UserRepository.GetUserByEmail(email);
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
                Console.WriteLine("/reports");
                Console.WriteLine();
                Console.WriteLine("Admin User's Commands :");
                Console.WriteLine();
                Console.WriteLine("/make-admin");
                Console.WriteLine("/remove-admin");
                Console.WriteLine("/show-admins");
                Console.WriteLine("/add-admin");
                Console.WriteLine("/logout");

                Console.WriteLine("Please enter command");
                string command = Console.ReadLine();

                if (command == "/show-users")
                {
                    List<Person> Users = UserRepository.GetAll();

                    foreach (Person oneuser in Users)
                    {
                        Console.WriteLine(oneuser.Id + " " + Person.Name + " " + Person.Lastname + " " + Person.Email);
                    }
                }
                else if (command == "/remove-user")
                {
                    Console.WriteLine("Please Enter email");
                    string targetemail = Console.ReadLine();

                    Person RemoveUser = UserRepository.GetUserByEmail(targetemail);
                    if (RemoveUser != null && Person.Email != Person.Email)
                    {
                        UserRepository.Delete(RemoveUser);
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
                    Person updateUser = UserRepository.GetUserByEmail(updateEmail);
                    if (!UserValidations.IsAdmin(updateUser) && !(Person.Email == Person.Email))
                    {
                        Person newUser = UserRepository.Update(updateUser);
                        Console.WriteLine($"{Person.Name} {Person.Lastname} succesfully updated to {Person.Name} {Person.Lastname}");

                    }
                    else
                    {
                        Console.WriteLine("Email not found ERROR");
                    }
                }
                else if (command == "/reports")
                {
                    List<Report> reports = ReportRepository.GetReports();
                    foreach (Report report in reports)
                    {
                        string isadmin = "";
                        if (report.ToUser is Admin)
                        {
                            isadmin = "Admin";
                        }
                        else
                        {
                            isadmin = "Not Admin";
                        }

                        Console.WriteLine($"{report.FromUser}  {report.ToUser}  {report.Text} {isadmin}");
                    }
                }

                else if (command == "/add-admin")
                {
                    Person adminUser = Authentication.Register();
                    UserRepository.Delete(adminUser);

                    Admin admin = new Admin(Person.Name, Person.Lastname, Person.Email, Person.Password, adminUser.Id);
                    UserRepository.Add(admin);
                    Console.WriteLine($"{Person.Name} {Person.Lastname} is the new Admin now");
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
                    Person user1 = UserRepository.GetUserByEmail(adminEmail);

                    if (user1 is Admin && Person.Email != Person.Email)
                    {
                        Console.WriteLine("You can`t make admin to admin");
                    }
                    else
                    {
                        UserRepository.Delete(user1);
                        Admin admin = new Admin(Person.Name, Person.Lastname, Person.Email, Person.Password, user1.Id);
                        UserRepository.Add(admin);
                        Console.WriteLine($"{Person.Name} {Person.Lastname} is Admin now");

                    }
                }
                else if (command == "/remove-admin")
                {
                    Console.WriteLine("Please enter email");
                    string targetemail = Console.ReadLine();

                    Person adminuser = UserRepository.GetUserByEmail(targetemail);
                    if (adminuser is Admin)
                    {

                        UserRepository.Delete(adminuser);
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

        public static void UserPanel(string email)
        {
            Person user = UserRepository.GetUserByEmail(email);
            Console.WriteLine($"User successfully authenticated : {user.GetInfo()}");
            Console.WriteLine();

            Console.WriteLine("commands : /logout \n /report ");
            string command = Console.ReadLine();

            if (command == "/report")
            {
                string targetemail = Console.ReadLine();
                Person reportUser = UserRepository.GetUserByEmail(targetemail);

                if (reportUser != null)
                {
                    Console.WriteLine("Please enter text");
                    string text = Console.ReadLine();

                    ReportRepository.Add(Person.Email, Person.Email, text);
                }

            }
            else if (command == "/logout")
            {
                CurrentUser = null;
                Program.Main(new string[] { });
            }

            else
            {
                Console.WriteLine("command not found");
            }
        }
    }
}
