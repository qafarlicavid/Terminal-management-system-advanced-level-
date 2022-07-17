using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.Database.Models
{
    class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Person(string name, string lastname, string email, string password)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }
        public string GetInfo()
        {
            return Name + Lastname;
        }
    }
}
