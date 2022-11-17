using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Officeb.Services
{
    public class MessageService
    {
        IMessageRepository _MessageRepository;
        public MessageService(IMessageRepository MessageRepository)
        {
            _MessageRepository = MessageRepository;
        }
        public void AddMessage(Message Message)
        {
            _MessageRepository.AddMessage(Message);
        }
        public void UpdateMessage(Message Message)
        {
            _MessageRepository.UpdateMessage(Message);
        }
        public void DeleteMessage(int MessageId)
        {
            _MessageRepository.DeleteMessage(MessageId);
        }
        //get movie by id
        public Message GetMessageById(int MessageId)
        {
            return _MessageRepository.GetMessageById(MessageId);
        }
        //get movies
        public IEnumerable<Message> GetMessages()
        {
            return _MessageRepository.GetMessage();
        }

        
    }
}
