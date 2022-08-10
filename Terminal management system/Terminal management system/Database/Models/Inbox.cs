using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models.Common;

namespace Terminal_management_system.Database.Models
{
    class Inbox : Entity<int>
    {
        public Person To { get; set; }
        public Blog Blog { get; set; }
        public string Message { get; set; }
        public Inbox(Person to, Blog blog, string message)
        {
            To = to;
            Blog = blog;
            Message = message;
        }

        public string GetMessage()
        {
            return To + " " + Blog.ID + " " + Message;
        }
    }
}
