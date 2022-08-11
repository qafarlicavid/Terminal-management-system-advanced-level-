using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.Database.Models
{
    public class Admin : Person
    {
        public Admin(string name, string lastname, string email, string password, int id)
            : base(name, lastname, email, password, id)
        {

        }
        public Admin(string firstName, string lastname, string email, string password)
            : base(firstName, lastname, email, password)
        {

        }

        public override string GetInfo()
        {
            return Id + " " + FirstName + " " + LastName + " " + Email;
        }
    }
}
