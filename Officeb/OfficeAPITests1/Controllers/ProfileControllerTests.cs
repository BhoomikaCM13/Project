using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OfficeBusiness.Services;
using OfficeDL.Repository;
using OfficeEntity;
using ProfileAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileAPI.Controllers.Tests
{
    [TestClass()]
    public class ProfileControllerTests
    {
        private Mock<IProfileRepository> profileRepositoryMock;
        private Fixture fixture;
        private ProfileController controller;



        public ProfileControllerTests()
        {
            fixture = new Fixture();
            profileRepositoryMock = new Mock<IProfileRepository>();
        }



        [TestMethod()]
        public async Task UpdateProfile_Expect_ProfileUpdated()
        {



            var profile = fixture.Create<Profile>();
            profileRepositoryMock.Setup(repo => repo.UpdateProfile(It.IsAny<Profile>()));
            controller = new ProfileController(new Profileservice(profileRepositoryMock.Object));
            var result = controller.UpdateProfile(profile);
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }



        [TestMethod()]



        public async Task Register_Expect_ProfileAdded()
        {



            var profile = fixture.Create<Profile>();
            profileRepositoryMock.Setup(repo => repo.Register(It.IsAny<Profile>()));
            controller = new ProfileController(new Profileservice(profileRepositoryMock.Object));
            var result = controller.Register(profile);
            var obj = result as ObjectResult;



            Assert.AreEqual(200, obj.StatusCode);
        }




        //[TestMethod()]
        //public void LoginTest()
        //{
        //    Assert.Fail();
        //}



        [TestMethod()]
        public async Task GetProfileById_Expect_ProfileById()
        {
            var profile = fixture.Create<Profile>();
            profileRepositoryMock.Setup(repo => repo.GetProfileById(profile.id)).Returns(profile);
            controller = new ProfileController(new Profileservice(profileRepositoryMock.Object));
            var result = controller.GetProfileById(profile.id);
            Assert.AreEqual(profile, result);
        }



        [TestMethod()]
        public async Task GetProfile_Expect_AllProfile()
        {
            var profileList = fixture.CreateMany<Profile>(3).ToList();
            profileRepositoryMock.Setup(repo => repo.GetProfiles()).Returns(profileList);
            controller = new ProfileController(new Profileservice(profileRepositoryMock.Object));
            var result = controller.GetProfiles();
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
