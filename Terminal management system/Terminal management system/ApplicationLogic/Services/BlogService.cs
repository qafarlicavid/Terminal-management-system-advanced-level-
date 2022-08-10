using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.ApplicationLogic.Validations;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Models.Enums;
using Terminal_management_system.Database.Repository;

namespace Terminal_management_system.ApplicationLogic.Services
{
    partial class BlogService  //when program starts
    {
        private static BlogRepository blogrepo = new BlogRepository();
        private static CommentRepository commentrepo = new CommentRepository();
        private static InboxRepository inboxRepository = new InboxRepository();

        public static void ShowBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();
            List<Comment> comments = commentrepo.GetAll();
            foreach (Blog blog in blogs)
            {
                if (blog.Status == BlogStatus.Approved)
                {
                    Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                    Console.WriteLine($"==={blog.Tittle}===");
                    Console.WriteLine(blog.Content);
                    Console.WriteLine();

                    Console.WriteLine("Comments: " + comments.Count);
                    foreach (Comment comment in comments)
                    {
                        if (comment.Blog == blog)
                        {
                            Console.WriteLine($"{comment.GetInfo()}");
                        }
                    }
                }


            }
        }

        public static void FilteredBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();
            List<Comment> comments = commentrepo.GetAll();
            Console.WriteLine("/tittle");
            Console.WriteLine("/firstname");
            Console.WriteLine("enter command");
            string command = Console.ReadLine();
            if (command == "/tittle")
            {
                Console.WriteLine("enter tittle :");
                string tittle = Console.ReadLine();

                foreach (Blog blog in blogs)
                {
                    if (blog.Tittle.Contains(tittle))
                    {
                        if (blog.Status == BlogStatus.Approved)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"==={blog.Tittle}===");
                            Console.WriteLine(blog.Content);
                            Console.WriteLine();

                            Console.WriteLine("Comments: " + comments.Count);
                            foreach (Comment comment in comments)
                            {
                                if (comment.Blog == blog)
                                {
                                    Console.WriteLine($"{comment.GetInfo()}");
                                }
                            }
                        }
                    }
                }

            }
            else if (command == "/firstname")
            {
                Console.WriteLine("enter firstname");
                string firstname = Console.ReadLine();
                foreach (Blog blog in blogs)
                {
                    if (blog.From.FirstName == firstname)
                    {
                        if (blog.Status == BlogStatus.Approved)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"==={blog.Tittle}===");
                            Console.WriteLine(blog.Content);
                            Console.WriteLine();

                            Console.WriteLine("Comments: " + comments.Count);
                            foreach (Comment comment in comments)
                            {
                                if (comment.Blog == blog)
                                {
                                    Console.WriteLine($"{comment.GetInfo()}");
                                }
                            }
                        }
                    }
                }
            }

        }

        public static void FindBlogByCode()
        {
            List<Comment> comments = commentrepo.GetAll();
            Console.WriteLine("Please enter code");
            string code = Console.ReadLine();

            Blog blog = BlogRepository.GetBlogbyId(code);
            if (blog != null)
            {
                Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                Console.WriteLine($"==={blog.Tittle}===");
                Console.WriteLine(blog.Content);
                Console.WriteLine();

                Console.WriteLine("Comments: " + comments.Count);
                foreach (Comment comment in comments)
                {
                    if (comment.Blog == blog)
                    {
                        Console.WriteLine($"{comment.GetInfo()}");
                    }
                }
            }
        }

    }

    partial class BlogService  //user`s methods
    {
        public static void Inbox()
        {

        }

        public static void MyBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();
            int rownumber = 1;
            foreach (Blog blog in blogs)
            {
                if (Dashboard.CurrentUser.Id == blog.From.Id)
                {
                    Console.WriteLine($"{rownumber} {blog.GetInfo()}");
                    rownumber++;
                }
            }
        }

        public static void AddBlog()
        {
            Console.WriteLine("Enter Tittle of blog :");
            string tittle = Console.ReadLine();
            while (!BaseValidations.IsLengthCorrect(tittle, 10, 35))
            {
                Console.WriteLine("Tittle's length must be min 10,max 35");
                tittle = Console.ReadLine();
            }

            Console.WriteLine("enter blog content");
            string content = Console.ReadLine();
            while (!BaseValidations.IsLengthCorrect(content, 20, 45))
            {
                Console.WriteLine("Content's length must be min 20,max 45");
                content = Console.ReadLine();
            }

            BlogRepository.AddBlog(Dashboard.CurrentUser, tittle, content);
        }

        public static void DeleteBlog()
        {
            Console.WriteLine("enter blog code :");
            string code = Console.ReadLine();

            Blog blog = BlogRepository.GetById(code);

            if (Dashboard.CurrentUser == blog.From)
            {
                blogrepo.Delete(blog);
                Console.WriteLine("your blog deleted succesfully.");
            }
            else
            {
                Console.WriteLine("You can remove only your blogs");
            }
        }

        public static void AddComment()
        {
            Console.WriteLine("Please enter blog's code which you want to comment");
            string code = Console.ReadLine();
            Blog blog = BlogRepository.GetById(code);
            if (blog != null)
            {
                Console.WriteLine("enter your comment");
                string comment = Console.ReadLine();
                while (!BaseValidations.IsLengthCorrect(comment, 10, 35))
                {
                    Console.WriteLine("Comment's length must be min 10,max 35");
                    comment = Console.ReadLine();
                }

                CommentRepository.Add(blog, Dashboard.CurrentUser, comment);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Blog not found");
                Console.WriteLine();
            }
        }

    }


    partial class BlogService  //Admin`s methods
    {
        public static void BlogManagement()
        {
            List<Blog> blogs = blogrepo.GetAll();
            List<Comment> comments = commentrepo.GetAll();

            foreach (Blog blog in blogs)
            {
                if (blog.Status == BlogStatus.Pending)
                {
                    Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.Status}] [{blog.From.FirstName}]" +
                        $"  [{blog.From.LastName}] ");
                    Console.WriteLine($"==={blog.Tittle}===");
                    Console.WriteLine(blog.Content);
                    Console.WriteLine();
                }


            }

            Console.WriteLine("Commands :");
            Console.WriteLine("/approve-blog");
            Console.WriteLine("/reject-blog");
            string command = Console.ReadLine();

            Console.WriteLine("Enter blog's code :");
            string code = Console.ReadLine();
            Blog auditingBlog = BlogRepository.GetByCode(code);
            string message = null;

            if (auditingBlog != null)
            {
                if (command == "/approve-blog")
                {
                    auditingBlog.Status = BlogStatus.Approved;
                    message = "Blog Approved";

                    Inbox inbox = new Inbox(auditingBlog.From, auditingBlog, message);
                    inboxRepository.Add(inbox);

                    Console.WriteLine("Blog Approved");
                }
                else if (command == "/reject-blog")
                {
                    auditingBlog.Status = BlogStatus.Rejected;
                    message = "Blog Rejected";

                    Inbox inbox = new Inbox(auditingBlog.From, auditingBlog, message);
                    inboxRepository.Add(inbox);
                    Console.WriteLine("Blog Rejected");
                }
                else
                {
                    Console.WriteLine("command not found");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Blog not found");
            }
        }
    }
}
