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
        private static List<Person> Persons { get; set; } = new List<Person>()
        {
            new Person("super", "admin", " admin@gmail.com ", "123321")
        };

        public static Person Register(string name, string lastname, string email, string password)
        {
            Person person = new Person(name, lastname, email, password);
            Persons.Add(person);
            return person;
        }
        public static Person Login(string email, string password)
        {
            Person person = new Person(email, password);
            Persons.Add(person);
            return person;
        }
    }
}
