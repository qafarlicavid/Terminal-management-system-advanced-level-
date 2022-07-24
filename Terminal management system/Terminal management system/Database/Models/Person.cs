using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.Database.Models
{
    class Person
    {
        public DateTime RegisterDate { get; set; }
        public int Id { get; private set; }

        private static int IdCounter = 1;
        public static string Name { get; set; }
        public static string Lastname { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }

        public Person(string name, string lastname, string email, string password)
        {
            RegisterDate = DateTime.Now;
            Id = IdCounter++;
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }
        public Person(string name, string surname, string email, string password, int id)
        {
            Name = name;
            Lastname = surname;
            Email = email;
            Password = password;
            Id = id;
        }
        public virtual string GetInfo()
        {
            return Name + " " + Lastname;
        }
    }
}
