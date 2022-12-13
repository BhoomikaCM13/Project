using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDL.Repository
{
    public class CommentRepository : ICommentRepository
    {
        Office_Context _OfficeDbcontext;
        public CommentRepository(Office_Context context)
        {
            _OfficeDbcontext = context;
        }

        public CommentRepository()
        {
        }

        public void AddComment(Comment comment)
        {
            #region ADD COMMENT
            _OfficeDbcontext.comments.Add(comment);
            _OfficeDbcontext.SaveChanges();
            #endregion
        }



        public void DeleteComment(int commentId)
        {
            #region DELETE COMMENT
            var comment = _OfficeDbcontext.comments.Find(commentId);
            _OfficeDbcontext.comments.Remove(comment);
            _OfficeDbcontext.SaveChanges();
            #endregion
        }
  
        public IEnumerable<Comment> GetComments()
        {
            #region GET ALL COMMENTS WITH PROFILE PROPERTY
            return _OfficeDbcontext.comments.Include(obj => obj.profile).ToList();
            #endregion
        }

      
        public Comment GetCommentById(int commentId)
        {
            #region GET COMMENT BY ID 
            return _OfficeDbcontext.comments.Find(commentId);
            #endregion
        }

        public void UpdateComment(Comment comment)
        {
            #region EDIT COMMENT
            _OfficeDbcontext.Entry(comment).State = EntityState.Modified;
            _OfficeDbcontext.SaveChanges();
            #endregion
        }

    }
}
 
