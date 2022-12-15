using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OfficeAPI.Controllers;
using OfficeBusiness.Services;
using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAPI.Controllers.Tests
{
    [TestClass()]
    public class MessageControllerTests
    {
        private Mock<IMessageRepository> messageRepositoryMock;
        private Fixture fixture;
        private MessageController controller;



        public MessageControllerTests()
        {
            fixture = new Fixture();
            messageRepositoryMock = new Mock<IMessageRepository>();
        }



        [TestMethod()]
        public async Task GetMessage_Expect_AllMessage()
        {
            var messageList = fixture.CreateMany<Message>(3).ToList();
            messageRepositoryMock.Setup(repo => repo.GetMessages()).Returns(messageList);
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.GetMessages();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task AddMessage_Expect_MessageAdded()
        {
            var message = fixture.Create<Message>();
            messageRepositoryMock.Setup(repo => repo.AddMessage(It.IsAny<Message>()));
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.AddMessage(message);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);           
        }

        [TestMethod()]
        public async Task AddMessage_Expect_MessageAdded1()
        {
            var message = fixture.Create<Message>();
            messageRepositoryMock.Setup(repo => repo.AddMessage(It.IsAny<Message>())).Throws(new Exception());
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.AddMessage(message);
            var obj = result as ObjectResult;
            Assert.AreEqual(obj.StatusCode, 400);
        }

        [TestMethod()]



        public async Task UpdateMessage_Expect_MessageUpdated()
        {



            var message = fixture.Create<Message>();
            messageRepositoryMock.Setup(repo => repo.UpdateMessage(It.IsAny<Message>()));
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.UpdateMessage(message);
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod()]

        public async Task UpdateMessage_Expect_MessageUpdated1()
        {



            var message = fixture.Create<Message>();
            messageRepositoryMock.Setup(repo => repo.UpdateMessage(It.IsAny<Message>())).Throws(new Exception());
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.UpdateMessage(message);
            var obj = result as ObjectResult;
            Assert.AreEqual(obj.StatusCode, 400);
        }


        [TestMethod()]



        public async Task DeleteMessage_Expect_MessageUpdated()
        {



            messageRepositoryMock.Setup(repo => repo.DeleteMessage(It.IsAny<int>()));
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.DeleteMessage(It.IsAny<int>());
            var obj = result as ObjectResult;


            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod()]

        public async Task DeleteMessage_Expect_MessageUpdated1()
        {
            messageRepositoryMock.Setup(repo => repo.DeleteMessage(It.IsAny<int>())).Throws(new Exception());
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.DeleteMessage(It.IsAny<int>());
            var obj = result as ObjectResult;


            Assert.AreEqual(obj.StatusCode, 400);
        }
      

        [TestMethod()]
        public async Task GetMessageById_Expect_MessageById()
        {
            var message = fixture.Create<Message>();
            messageRepositoryMock.Setup(repo => repo.GetMessageById(message.id)).Returns(message);
            controller = new MessageController(new MessageService(messageRepositoryMock.Object));
            var result = controller.GetMessageById(message.id);
            Assert.AreEqual(message, result);
        }
    }
}