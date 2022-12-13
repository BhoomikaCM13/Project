using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
    public interface IMessageRepository
    {
        //Method Definition's for MessageEntity
        void AddMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(int messageId);
        Message GetMessageById(int messageId);
        IEnumerable<Message> GetMessages();


    }
}
