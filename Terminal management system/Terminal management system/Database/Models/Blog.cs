using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models.Common;
using Terminal_management_system.Database.Models.Enums;
using Terminal_management_system.Database.Repository;

namespace Terminal_management_system.Database.Models
{
    public class Blog : Entity<string>
    {
        public Person From { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public DateTime CreadetTime { get; set; }
        public BlogStatus Status { get; set; }


        public Blog(Person from, string tittle, string content, BlogStatus status, string id = null)
        {

            From = from;
            Tittle = tittle;
            Content = content;
            Status = status;

            CreadetTime = DateTime.Now;
            if (id != null)
            {
                ID = id;
            }
            else
            {
                ID = BlogRepository.RandomCode;
            }

        }
        public string GetInfo()
        {
            return "Time : " + CreadetTime.ToString("dd.MM.yyyy") + " ID : " + ID + " Tittle : " + Tittle + " Content: " + Content + "- Status : " + Status;
        }
    }
}
