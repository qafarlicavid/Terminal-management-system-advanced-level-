using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository
{
    class InboxRepository : Repository.Common.Repository<Inbox, int>
    {
        public static Inbox Add(Person to, Blog blog, string message)
        {
            Inbox inbox = new Inbox(to, blog, message);
            DbContext.Add(inbox);
            return inbox;
        }
    }
}
