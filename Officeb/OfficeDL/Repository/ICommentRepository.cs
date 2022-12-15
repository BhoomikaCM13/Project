using OfficeEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
    public interface ICommentRepository
    {
        //Method Definition's for CommentEntity
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
        Comment GetCommentById(int commentId);
        IEnumerable<Comment> GetComments();
      
    }
}
