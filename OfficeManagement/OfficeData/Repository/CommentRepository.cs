using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeData.Repository
{
    public class CommentRepository : ICommentRepository
    {
            OfficeDbContext _OfficeDbcontext;
            public CommentRepository(OfficeDbContext context)
            {
                _OfficeDbcontext = context;
            }
            public void AddComment(Comment comment)
            {
                _OfficeDbcontext.comments.Add(comment);
                _OfficeDbcontext.SaveChanges();
            }
            public void DeleteComment(int commentId)
            {
                var movie = _OfficeDbcontext.comments.Find(commentId);
                _OfficeDbcontext.comments.Remove(movie);
                _OfficeDbcontext.SaveChanges();
            }
            public IEnumerable<Comment> GetComments()
            {
                return _OfficeDbcontext.comments.ToList();
            }
             public Comment GetCommentById(int commentid)
             {
                return _OfficeDbcontext.comments.Find(commentid);
             }
        public void UpdateComment(Comment comment)
            {
                _OfficeDbcontext.Entry(comment).State = EntityState.Modified;
                _OfficeDbcontext.SaveChanges();
            }
        }
}
