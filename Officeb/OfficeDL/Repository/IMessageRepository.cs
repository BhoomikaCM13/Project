using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(int messageid);
        Message GetMessageById(int Messageid);
        IEnumerable<Message> GetMessage();


    }
}
