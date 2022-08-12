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
    partial class BlogService 
    {
        private static BlogRepository blogRepo = new BlogRepository();
        private static CommentRepository commentRepo = new CommentRepository();
        private static InboxRepository inboxRepo = new InboxRepository();

        public static void ShowBlogsWithComments()
        {
            List<Blog> blogs = blogRepo.GetAll();
            List<Comment> comments = commentRepo.GetAll();
            foreach (Blog blog in blogs)
            {
                if (blog.Status == BlogStatus.Approved)
                {
                    Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                    Console.WriteLine($"Tittle Name : {blog.Tittle}");
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
            List<Blog> blogs = blogRepo.GetAll();
            List<Comment> comments = commentRepo.GetAll();
            Console.WriteLine("/tittle");
            Console.WriteLine("/firstname");
            Console.WriteLine("enter command");
            string command = Console.ReadLine();
            if (command == "/tittle")
            {
                Console.WriteLine("Enter tittle : ");
                string tittle = Console.ReadLine();

                foreach (Blog blog in blogs)
                {
                    if (blog.Tittle.Contains(tittle))
                    {
                        if (blog.Status == BlogStatus.Approved)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"Tittle Name : {blog.Tittle}");
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
                Console.WriteLine("Enter firstname : ");
                string firstname = Console.ReadLine();
                foreach (Blog blog in blogs)
                {
                    if (blog.From.FirstName == firstname)
                    {
                        if (blog.Status == BlogStatus.Approved)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"Tittle Name : {blog.Tittle}");
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
            List<Comment> comments = commentRepo.GetAll();
            Console.Write("Please enter code : ");
            string code = Console.ReadLine();
            Blog blog = blogRepo.GetBlogbyId(code);

            if (blog != null)
            {
                Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.FirstName}]  [{blog.From.LastName}] ");
                Console.WriteLine($"Tittle Name : {blog.Tittle}");
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

    partial class BlogService
    {
        public static void Inbox()
        {
            List<Inbox> inboxes = inboxRepo.GetAll();
            if (inboxes != null)
            {
                foreach (Inbox inbox in inboxes)
                {
                    if (inbox.To == Dashboard.CurrentUser)
                    {
                        Console.WriteLine(inbox.Message);

                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("|---Empty---|");
            }
        }

        public static void MyBlogs()
        {
            List<Blog> blogs = blogRepo.GetAll();
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

            Console.WriteLine("Enter blog content : ");
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
            Console.WriteLine("Enter blog code : ");
            string code = Console.ReadLine();

            Blog blog = blogRepo.GetById(code);

            if (Dashboard.CurrentUser == blog.From)
            {
                blogRepo.Delete(blog);
                Console.WriteLine("Your blog deleted succesfully");
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

            Blog blog = blogRepo.GetById(code);
            if (blog != null)
            {
                Console.WriteLine("Enter your comment : ");
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
                Console.WriteLine("Blog not found!");
                Console.WriteLine();
            }
        }
        public static void ShowBlogs()
        {
            BlogRepository blogRepo = new BlogRepository();
            List<Blog> blogs = blogRepo.GetAll();
            
            if (blogs != null)
            {
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine($"{blog.ID}. Owner: {blog.From.FirstName}, Content: {blog.Content}, Date: {blog.CreadetTime}, Blog status: {blog.Status}.");
                }
            }
            else
            {
                Console.WriteLine("empty");
            }
        }

    }


    partial class BlogService
    {
        public static void BlogManagement()
        {
            List<Blog> blogs = blogRepo.GetAll();
            List<Comment> comments = commentRepo.GetAll();

            foreach (Blog blog in blogs)
            {
                if (blog.Status == BlogStatus.Pending)
                {
                    Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.Status}] [{blog.From.FirstName}]" +
                        $"  [{blog.From.LastName}] ");
                    Console.WriteLine($"---==={blog.Tittle}===---");
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
            Blog auditingBlog = blogRepo.GetById(code);
            string message = null;

            if (auditingBlog != null)
            {
                if (command == "/approve-blog")
                {
                    auditingBlog.Status = BlogStatus.Approved;
                    message = "Blog Approved";

                    Inbox inbox = new Inbox(auditingBlog.From, auditingBlog, message);
                    inboxRepo.Add(inbox);

                    Console.WriteLine("Blog Approved");
                }
                else if (command == "/reject-blog")
                {
                    auditingBlog.Status = BlogStatus.Rejected;
                    message = "Blog Rejected";

                    Inbox inbox = new Inbox(auditingBlog.From, auditingBlog, message);
                    inboxRepo.Add(inbox);
                    Console.WriteLine("Blog Rejected");
                }
                else
                {
                    Console.WriteLine("Command not found!");
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
