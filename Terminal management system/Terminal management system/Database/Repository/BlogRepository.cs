using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Models.Enums;
using Terminal_management_system.Database.Repository.Common;

namespace Terminal_management_system.Database.Repository
{
    public class BlogRepository : Repository<Blog, int>
    {
        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next(0, 99999);
                return _code;
            }

        }
        public static List<Blog> Blogs { get; set; } = new List<Blog>();

        public static Blog AddBlog(Person from, string tittle, string text)
        {
            Blog blog = new Blog(from, tittle, text, BlogStatus.Pending);
            DbContext.Add(blog);
            return blog;
        }
        public void ShowBlogs()
        {
            foreach (Blog blog in DbContext)
            {
                Console.WriteLine($"{blog.Id}. Owner: {blog.From.FirstName}, Content: {blog.Content}, Date: {blog.CreadetTime}, Blog status: {blog.Status}.");
            }
        }
        public Blog GetBlogbyId(int id)
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
            int id = int.Parse(Console.ReadLine());
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
