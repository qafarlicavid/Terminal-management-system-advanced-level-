using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models.Enums;

namespace Terminal_management_system.Database.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public static int IdCounter { get; set; } = 1;
        public Person Owner { get; set; }
        public string Content { get; set; }
        public DateTime BlogDateTime { get; set; }
        public BlogStatus blogStatus { get; set; }

        public Blog(Person owner, string content)
        {
            Id = IdCounter++;
            Owner = owner;
            Content = content;
            BlogDateTime = DateTime.Now;
            blogStatus = BlogStatus.Pending;
        }
    }
}
