using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository.Common;

namespace Terminal_management_system.Database.Repository
{
    class CommentRepository
    {
        class CommentRepository : Repository<Comment, int>
        {
            static CommentRepository()
            {
                Blog blog = BlogRepository.GetBlogbyId("BL002");
                Blog blog1 = BlogRepository.GetBlogbyId("BL001");

                Person user = Repository<Person, int>.GetById(1);
                Person user1 = Repository<Person, int>.GetById(2);
                Person user2 = Repository<Person, int>.GetById(3);

                DbContext.Add(new Comment(blog1, user, "It is perfect!!!!!!!!"));
                DbContext.Add(new Comment(blog1, user1, "good!"));
                DbContext.Add(new Comment(blog, user2, "HI!"));
                DbContext.Add(new Comment(blog, user2, "Not Bad"));
            }

            public static Comment Add(Blog blog, Person from, string text)
            {
                Comment comments = new Comment(blog, from, text);
                DbContext.Add(comments);
                return comments;
            }

            public static List<Comment> GetCommentsByBlog(Blog blog)
            {
                List<Comment> comments = new List<Comment>();
                foreach (Comment comment in DbContext)
                {
                    if (comment.Blog == blog)
                    {
                        comments.Add(comment);
                    }
                }
                return comments;
            }
        }
    }
}

