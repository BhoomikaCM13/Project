using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeData.Repository
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentid);
        Comment GetCommentById(int commentid);
        IEnumerable<Comment> GetComments();
    }
}
