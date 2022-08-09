﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;

namespace Terminal_management_system.Database.Repository.Common
{
    public class BlogRepository
    {
        public static List<Blog> Blogs { get; set; } = new List<Blog>();

        public Blog AddBlog(Person owner, string content)
        {
            Blog blog = new Blog(owner, content);
            Blogs.Add(blog);
            return blog;
        }
        public void ShowBlogs()
        {
            foreach (Blog blog in Blogs)
            {
                Console.WriteLine($"{blog.Id}. Owner: {blog.Owner.FirstName}, Content: {blog.Content}, Date: {blog.BlogDateTime}, Blog status: {blog.blogStatus}.");
            }
        }
        public Blog GetBlogbyId(int id)
        {
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
