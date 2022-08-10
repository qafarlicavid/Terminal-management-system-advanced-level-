using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models.Common;

namespace Terminal_management_system.Database.Models
{
     class Comment : Entity<int>
    {
        public Blog Blog { get; set; }
        private static int _rowNumber = 1;
        public int RowNumber { get; set; }
        public Person From { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public Comment(Blog blog, Person from, string content)
        {
            Blog = blog;
            RowNumber = _rowNumber;
            From = from;
            Content = content;
            CreatedTime = DateTime.Now;
            _rowNumber++;
        }

        public string GetInfo()
        {
            return RowNumber + " " + CreatedTime.ToString("mm.dd.yyyy") + " " + From.FirstName + " " + From.LastName + " " + Content;
        }
    }
}
