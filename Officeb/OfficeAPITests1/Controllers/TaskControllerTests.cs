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
        public class TaskControllerTests
        {
            private Mock<ITaskRepository> taskRepositoryMock;
            private Fixture fixture;
            private TaskController controller;



            public TaskControllerTests()
            {
                fixture = new Fixture();
                taskRepositoryMock = new Mock<ITaskRepository>();
            }



            [TestMethod()]
            public async Task GetTask_Expect_AllTask()
            {

                var taskList = fixture.CreateMany<Tasks>(3).ToList();
                taskRepositoryMock.Setup(repo => repo.GetAllTasks()).Returns(taskList);
                controller = new TaskController(new TaskService(taskRepositoryMock.Object));
                var result = controller.GetTask();

                Assert.AreEqual(result, taskList);
            }




            [TestMethod()]



            public async Task AddTask_Expect_TaskAdded()
            {



                var task = fixture.Create<Tasks>();
                taskRepositoryMock.Setup(repo => repo.AddTask(It.IsAny<Tasks>()));
                controller = new TaskController(new TaskService(taskRepositoryMock.Object));
                var result = controller.AddTask(task);
                var obj = result as ObjectResult;



                Assert.AreEqual(200, obj.StatusCode);
            }




            [TestMethod()]



            public async Task UpdateTask_Expect_TaskUpdated()
            {



                var task = fixture.Create<Tasks>();
                taskRepositoryMock.Setup(repo => repo.UpdateTask(It.IsAny<Tasks>()));
                controller = new TaskController(new TaskService(taskRepositoryMock.Object));
                var result = controller.UpdateTask(task);
                var obj = result as ObjectResult;



                Assert.AreEqual(200, obj.StatusCode);
            }




            [TestMethod()]



            public async Task DeleteTask_Expect_TaskUpdated()
            {



                taskRepositoryMock.Setup(repo => repo.DeleteTask(It.IsAny<int>()));
                controller = new TaskController(new TaskService(taskRepositoryMock.Object));
                var result = controller.DeleteTask(It.IsAny<int>());
                var obj = result as ObjectResult;



                Assert.AreEqual(200, obj.StatusCode);
            }




            [TestMethod()]
            public async Task GetTaskById_Expect_TaskById()
            {



                var task = fixture.Create<Tasks>();
                taskRepositoryMock.Setup(repo => repo.GetTaskById(task.id)).Returns(task);
                controller = new TaskController(new TaskService(taskRepositoryMock.Object));
                var result = controller.GetTaskById(task.id);




                Assert.AreEqual(task, result);




            }
        }
    }
