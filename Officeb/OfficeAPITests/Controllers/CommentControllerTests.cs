using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeAPI.Controllers;
using OfficeDL;
using OfficeDL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeAPI.Controllers.Tests
{
    [TestClass()]
    public class CommentControllerTests
    {
        CommentController _commentController;
        CommentRepository _commentRepository;
        Office_Context a = new Office_Context();
        [TestInitialize]
        public void setup()
        {
            _commentController = new CommentController(new CommentRepository());
        }

        [TestMethod()]
        public void GetCommentsTest()
        {
            _commentController.Index();
            Assert.Fail();
        }
    }
}