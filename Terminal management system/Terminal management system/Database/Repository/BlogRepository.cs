using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Models.Enums;
using Terminal_management_system.Database.Repository.Common;

namespace Terminal_management_system.Database.Repository
{
    public class BlogRepository : Repository<Blog, string>
    {
        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next(1000, 10000);
                return _code;
            }

        }
        static BlogRepository()
        {
            BlogRepository blogRepo = new BlogRepository();
            UserRepository userRepo = new UserRepository();

            DbContext.Add(new Blog(userRepo.GetUserByEmail("cavid@gmail.com"), "Basliq", "Cavid salam deyir", BlogStatus.Approved, "1"));
        }
        public static List<Blog> Blogs { get; set; } = new List<Blog>();

        public static Blog AddBlog(Person from, string tittle, string text)
        {
            Blog blog = new Blog(from, tittle, text, BlogStatus.Pending);
            DbContext.Add(blog);
            return blog;
        }
      
        public Blog GetBlogbyId(string id)
        {
            List<Blog> blogs = new List<Blog>();

            foreach (Blog blog in Blogs)
            {
                if (blog.Id == id)
                {
                    return blog;
                }

            }
            return null;
        }
        public void DeleteBlogs()
        {
            Console.Write("Which blog do you want delete, write id : ");
            string id = Console.ReadLine();
            foreach (Blog blog in Blogs)
            {
                if (blog.Id == id)
                {
                    Blogs.Remove(blog);
                    Console.WriteLine("Blog deleted. ");
                    break;
                }
                Console.WriteLine($"{id} blog is not in system. ");
            }
        }
        public void DeleteAllBlog()
        {
            Blogs.Clear();
        }
    }
}
