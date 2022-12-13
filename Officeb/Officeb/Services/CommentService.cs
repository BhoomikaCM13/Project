using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Services
{
    public class CommentService
    {
        ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // CRUD Service Operations for Comment:

        public void AddComment(Comment comment)
        {
            _commentRepository.AddComment(comment);
        }
        public void UpdateComment(Comment comment)
        {
            _commentRepository.UpdateComment(comment);
        }
        public void DeleteComment(int commentId)
        {
            _commentRepository.DeleteComment(commentId);
        }
        //get movie by id
        public Comment GetCommentById(int commentId)
        {
            return _commentRepository.GetCommentById(commentId);
        }
        //get movies
        public IEnumerable<Comment> GetComments()
        {
            return _commentRepository.GetComments();
        }
      
    }
}
