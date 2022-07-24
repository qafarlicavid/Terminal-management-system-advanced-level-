using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository
{
    class UserRepository
    {
        private static int _idcounter;

        public static int IDCounter
        {
            get
            {
                _idcounter++;
                return _idcounter;
            }
        }
        public static List<Person> Persons { get; set; } = new List<Person>()
            {
            new Admin ("Super","admin","admin@gmail.com","123321"),
            new Person ("Javid","Gafarli","cavid@gmail.com","123321")
        };


        public static void Add(string name, string lastName, string email, string password)
        {

            Person user = new Person(name, lastName, email, password, IDCounter);
            Persons.Add(user);
        }
        public static Person Add(string name, string surname, string email, string password, int id)
        {
            Person user = new Person(name, surname, email, password, id);
            Persons.Add(user);
            return user;
        }

        public static Person Add(Person user)
        {
            Persons.Add(user);
            return user;
        }
        public static Person Add(Admin admin)
        {
            Persons.Add(admin);
            return admin;
        }


        public static void Delete(Person user)
        {
            Persons.Remove(user);
        }
        public static List<Person> GetAll()
        {
            return Persons;
        }


        public static Person GetUserByEmail(string email)
        {
            foreach (Person user in Persons)
            {
                if (Person.Email == email)
                {
                    return user;
                }
            }
            return null;
        }


        public static bool RemoveUserByEmail(string email)
        {
            foreach (Person user in Persons)
            {
                if (Person.Email == email)
                {
                    Persons.Remove(user);
                    return true;
                }
            }
            return false;
        }


        public static Person Update(Person user)
        {
            Console.WriteLine("Please enter name");
            string name = Console.ReadLine();
            while (!UserValidations.IsNameValid(name))
            {
                Console.WriteLine("Please enter name again");
                name = Console.ReadLine();
            }
            Console.WriteLine("Please enter surname");
            string surname = Console.ReadLine();
            while (!UserValidations.IsSurnameValid(surname))
            {
                Console.WriteLine("Please enter surname");
                surname = Console.ReadLine();
            }
            Person.Name = name;
            Person.Lastname = surname;
            return user;
        }

        public static void ShowAdmins()
        {
            foreach (Person user in Persons)
            {
                if (user is Admin)
                {
                    Console.WriteLine(user.GetInfo());
                }
            }
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
