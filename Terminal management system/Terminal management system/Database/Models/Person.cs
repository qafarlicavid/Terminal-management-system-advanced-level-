using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.Database.Models
{
    class Person
    {
        public static string Name { get; set; }
        public static string Lastname { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }

        public Person(string name, string lastname, string email, string password)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }
        public Person(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        
        public static string GetRegisterInfo()
        {
            return Name + " " + Lastname + " " + Email;
        }
        public static string GetLoginInfo()
        {
            return Name + " " + Lastname;
        }
    }
}
