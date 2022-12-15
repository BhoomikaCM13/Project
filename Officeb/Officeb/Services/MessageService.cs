using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBusiness.Services
{
    public class MessageService
    {
        IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // CRUD Service Operations for Message:
        public void AddMessage(Message message)
        {
            _messageRepository.AddMessage(message);
        }
        public void UpdateMessage(Message message)
        {
            _messageRepository.UpdateMessage(message);
        }
        public void DeleteMessage(int messageId)
        {
            _messageRepository.DeleteMessage(messageId);
        }
        //get movie by id
        public Message GetMessageById(int messageId)
        {
            return _messageRepository.GetMessageById(messageId);
        }
        //get movies
        public IEnumerable<Message> GetMessages()
        {
            return _messageRepository.GetMessages();
        }

        
    }
}
