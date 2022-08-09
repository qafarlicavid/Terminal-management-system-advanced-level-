using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository
{
    class UserRepository : Common.Repository<Person, int> // full qualified namespace
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }
        static UserRepository()
        {
            SeedUsers();
        }

        private static void SeedUsers()
        {
            DbContext.Add(new Admin("Mahmood", "Garibov", "qaribovmahmud@gmail.com", "123321"));
            DbContext.Add(new Admin("Eshqin", "Mahmudov", "eshqin@gmail.com", "123321"));
            DbContext.Add(new Person("Cavid", "Qafarli", "cavid@gmail.com", "123321"));
            DbContext.Add(new Person("Hesen", "Esedov", "hesen@gmail.com", "123321"));
        }

        public Person AddUser(string firstName, string lastName, string email, string password)
        {
            Person user = new Person(firstName, lastName, email, password, IdCounter);
            DbContext.Add(user);
            return user;
        }

        public Person AddUser(string firstName, string lastName, string email, string password, int id)
        {
            Person user = new Person(firstName, lastName, email, password, id);
            DbContext.Add(user);
            return user;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            foreach (Person user in DbContext)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static Person GetUserByEmailAndPassword(string email, string password)
        {
            foreach (Person user in DbContext)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (Person user in DbContext)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }

            return false; ;
        }

        public Person GetUserByEmail(string email)
        {
            foreach (Person user in DbContext)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }
        public static Person GetUserById(int id)
        {
            foreach (Person user in DbContext)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }
        public static void ShowAdmins()
        {
            foreach (Person user in DbContext)
            {
                if (user is Admin)
                {
                    Console.WriteLine($"Name: {user.FirstName}, Lastname: {user.LastName}, Email: {user.Email}  Date: {user.CreatedAt}");
                }
            }
        }
        public static void ShowUsers()
        {
            foreach (Person user in DbContext)
            {
                if (user is not Admin)
                {
                    Console.WriteLine($"Name: {user.FirstName}, Lastname: {user.LastName}, Email: {user.Email}  Date: {user.CreatedAt}");
                }
            }
        }
        public void UpdateInfo(Person person)
        {
            if (Authentication.IsAuthorized)
            {
                IsValidInfo(person);
            }
        }
        public void UpdateUserbyId(int id)
        {
            foreach (Person user in DbContext)
            {
                if (user.Id == id)
                {
                    IsValidInfo();
                }
            }

        }
        private static Person IsValidInfo(Person person)
        {
            Console.Write("Write new name: ");
            string newFirstName = Console.ReadLine();
            Console.Write("Write new lastname: ");
            string newLastName = Console.ReadLine();

            if (UserValidations.IsNameValid(newFirstName) &
            UserValidations.IsSurnameValid(newLastName))
            {
                Authentication.Account.FirstName = person.FirstName;
                Authentication.Account.LastName = person.LastName;
            }
            return person;
        }
    }
}
