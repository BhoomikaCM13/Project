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
        public void AddMessage(Message Message)
        {
            _OfficeDbcontext.messages.Add(Message);
            _OfficeDbcontext.SaveChanges();
        }
        public void DeleteMessage(int MessageId)
        {
            var movie = _OfficeDbcontext.messages.Find(MessageId);
            _OfficeDbcontext.messages.Remove(movie);
            _OfficeDbcontext.SaveChanges();
        }
        public IEnumerable<Message> GetMessage()
        {
            return _OfficeDbcontext.messages.Include(obj => obj.Profile).ToList();
        }
        public Message GetMessageById(int Messageid)
        {
            return _OfficeDbcontext.messages.Find(Messageid);
        }
        public void UpdateMessage(Message Message)
        {
            _OfficeDbcontext.Entry(Message).State = EntityState.Modified;
            _OfficeDbcontext.SaveChanges();
        }

       
    }
}