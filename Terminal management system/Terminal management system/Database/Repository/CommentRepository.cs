using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_management_system.Database.Models;
using Terminal_management_system.Database.Repository.Common;

namespace Terminal_management_system.Database.Repository
{
    class CommentRepository : Repository<Comment, int>
    {
        static CommentRepository()
        {
            BlogRepository blogRepo = new BlogRepository();
            UserRepository userRepo = new UserRepository();

            DbContext.Add(new Comment(blogRepo.GetById("1"),userRepo.GetUserByEmail("cavid@gmail.com"),"beyendim"));
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

