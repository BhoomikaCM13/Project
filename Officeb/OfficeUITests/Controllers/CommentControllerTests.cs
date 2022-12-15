using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeUI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeUI.Controllers.Tests
{
    [TestClass()]
    public class CommentControllerTests
    {
       
        CommentController commentController;
        [TestInitialize]
        public void setup()
        {
            commentController = new CommentController();
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            commentController.Index();

            //Assert
            Assert.AreEqual(commentController.Index(),"");
            Assert.Fail();
        }
        [TestCleanup]
        public void cleanUp()
        {

        }
    }
}