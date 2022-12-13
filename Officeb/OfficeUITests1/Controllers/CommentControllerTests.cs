using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeDL.Repository;
using OfficeDL;
using OfficeUI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeUI.Controllers.Tests
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
        public void IndexTest()
        {
            _commentController.Index();
            Assert.Fail();
        }
    }
}