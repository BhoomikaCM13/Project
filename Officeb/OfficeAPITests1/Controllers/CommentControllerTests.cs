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
using System.Text;

namespace OfficeAPI.Controllers.Tests
{
    [TestClass()]
    public class CommentControllerTests
    {



        private Mock<ICommentRepository> commentRepositoryMock;
        private Fixture fixture;
        private CommentController commentcontroller;



        public CommentControllerTests()
        {
            fixture = new Fixture();
            commentRepositoryMock = new Mock<ICommentRepository>();
        }



        [TestMethod()]
        public async Task GetComment_Expect_AllComment()
        {



            var commentList = fixture.CreateMany<Comment>(3).ToList();
            commentRepositoryMock.Setup(repo => repo.GetComments()).Returns(commentList);
            commentcontroller = new CommentController(new CommentService(commentRepositoryMock.Object));
            var result = commentcontroller.GetComments();



            Assert.AreEqual(result.Count(), 3);
        }




        [TestMethod()]



        public async Task AddComment_Expect_CommentAdded()
        {



            var comment = fixture.Create<Comment>();
            commentRepositoryMock.Setup(repo => repo.AddComment(It.IsAny<Comment>()));
            commentcontroller = new CommentController(new CommentService(commentRepositoryMock.Object));
            var result = commentcontroller.AddComment(comment);
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }




        [TestMethod()]



        public async Task UpdateComment_Expect_CommentUpdated()
        {



            var comment = fixture.Create<Comment>();
            commentRepositoryMock.Setup(repo => repo.UpdateComment(It.IsAny<Comment>()));
            commentcontroller = new CommentController(new CommentService(commentRepositoryMock.Object));
            var result = commentcontroller.UpdateComment(comment);
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }




        [TestMethod()]



        public async Task DeleteComment_Expect_CommentUpdated()
        {



            commentRepositoryMock.Setup(repo => repo.DeleteComment(It.IsAny<int>()));
            commentcontroller = new CommentController(new CommentService(commentRepositoryMock.Object));
            var result = commentcontroller.DeleteComment(It.IsAny<int>());
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }




        [TestMethod()]
        public async Task GetCommentById_Expect_CommentById()
        {



            var comment = fixture.Create<Comment>();
            commentRepositoryMock.Setup(repo => repo.GetCommentById(comment.id)).Returns(comment);
            commentcontroller = new CommentController(new CommentService(commentRepositoryMock.Object));
            var result = commentcontroller.GetCommentById(comment.id);



            Assert.AreEqual(comment, result);




        }
    }
}