using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDL.Repository
{
    public class MessageRepository : IMessageRepository
    {
        Office_Context _OfficeDbcontext;
        public MessageRepository(Office_Context context)
        {
            _OfficeDbcontext = context;
        }

      
        public void AddMessage(Message message)
        {
            #region ADD MESSAGE
            _OfficeDbcontext.messages.Add(message);
            _OfficeDbcontext.SaveChanges();
            #endregion
        }


       
        public void DeleteMessage(int messageId)
        {
            #region DELETE MESSAGE
            var message = _OfficeDbcontext.messages.Find(messageId);
            _OfficeDbcontext.messages.Remove(message);
            _OfficeDbcontext.SaveChanges();
            #endregion
        }

     
        public IEnumerable<Message> GetMessages()
        {
            #region GET ALL MESSAGE WITH PROFILE PROPERTY
            return _OfficeDbcontext.messages.Include(obj=>obj.Profile).ToList();
            #endregion
        }
   
        public Message GetMessageById(int messageId)
        {
            #region GET MESSAGE BY ID
            return _OfficeDbcontext.messages.Find(messageId);
            #endregion
        }

       
        public void UpdateMessage(Message message)
        {
            #region EDIT MESSAGE
            _OfficeDbcontext.Entry(message).State = EntityState.Modified;
            _OfficeDbcontext.SaveChanges();
            #endregion
        }

    }
}