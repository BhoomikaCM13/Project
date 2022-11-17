﻿using Microsoft.EntityFrameworkCore;
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
                    return _OfficeDbcontext.comments.Include(obj => obj.Profile).ToList();
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

        public List<Comment> GetCommentsByTaskId(int taskId)
        {
            List<Comment> comments = _OfficeDbcontext.comments.Include(obj => obj.Task).Include(obj=>obj.Profile).ToList();
            List<Comment> result = new List<Comment>();
            foreach(var comment in comments)

            {
                if( comment.TaskId== taskId)
                {
                    result.Add(comment);
                }
            }
            return result;
        }
    }
        }
 
