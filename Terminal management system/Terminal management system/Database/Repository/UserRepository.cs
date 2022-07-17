using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository
{
    class UserRepository
    {
        public static List<Person> Persons { get; set; } = new List<Person>();


        public static void Add(string name, string lastName, string email, string password)
        {

            Person user = new Person(name, lastName, email, password);
            Persons.Add(user);
        }

        public static bool IsEqualConfirmPassword(string password, string comfirmPassword)
        {
            if (comfirmPassword == password)
            {
                return true;
            }

            Console.WriteLine("Passwords isn't same! ");

            return false;
        }
        public static bool IsUserExistsByEmail(string email, string comfirmPassword)
        {
            foreach (Person user in Persons)
            {

                if (Person.Email == email && Person.Password == comfirmPassword)
                {
                    foreach (Person user1 in Persons)
                    {
                        if (user1.Id == user.Id)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
        public static void ShowAllUsers()
        {
            foreach (Person user in Persons)
            {
                Console.WriteLine(user.GetInfo());
            }
        }
    }
}
