using OfficeData.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Service
{
    public  class CommentService
    {
        ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void AddComment(Comment comment)
        {
            _commentRepository.AddComment(comment);
        }
        public void UpdateComment(Comment comment)
        {
            _commentRepository.UpdateComment(comment);
        }
        public void DeleteComment(int CommentId)
        {
            _commentRepository.DeleteComment(CommentId);
        }
        //get movie by id
        public Comment GetCommentById(int CommentId)
        {
            return _commentRepository.GetCommentById(CommentId);
        }
        //get movies
        public IEnumerable<Comment> GetComments()
        {
            return _commentRepository.GetComments();
        }
    }
}
