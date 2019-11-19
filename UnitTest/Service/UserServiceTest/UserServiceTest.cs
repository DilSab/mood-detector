﻿using Moq;
using Xunit;
using Model;
using ControllerProject.Service;
using System.Data.Entity;
using Model.Entity;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest.Service.UserServiceTest
{
    public class UserServiceTest
    {
        [Fact]
        public void TestAddNewUser()
        {
            var mockSet = new Mock<DbSet<LoginInfo>>();

            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(m => m.LoginInfoes).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            UserWithLogin user = CreateAddUser();
            service.AddNewUser(user);

            mockSet.Verify(m => m.Add(It.IsAny<LoginInfo>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void TestGetUser()
        {
            var users = new List<User>
            {
                new User { Id = 1, Firstname = "James", Lastname = "Smith", AccessRights = "Teacher" },
            }.AsQueryable();

            var mockSet = GetUserMockSet(users);

            var loginData = new List<LoginInfo>
            {
                new LoginInfo { Id = 1, UserId = 1, Username = "smith123", Email = "james.smith@email.com", Password = "Password123" },
            }.AsQueryable();

            var loginMockSet = GetLoginMockSet(loginData);
            
            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            mockContext.Setup(c => c.LoginInfoes).Returns(loginMockSet.Object);

            var service = new UserService(mockContext.Object);
            
            var user = service.GetUser("smith123");

            Assert.Equal(1, user.Id);
            Assert.Equal("James", user.Firstname);
            Assert.Equal("Smith", user.Lastname);
            Assert.Equal("Teacher", user.AccessRights);
        }

        [Fact]
        public void TestGetUsers()
        {
            var users = new List<User>
            {
                new User { Id = 1, Firstname = "James", Lastname = "Smith", AccessRights = "Teacher" },
                new User { Id = 2, Firstname = "John", Lastname = "Williams", AccessRights = "Admin" },
                new User { Id = 3, Firstname = "Linda", Lastname = "Johnson", AccessRights = "Teacher" },
            }.AsQueryable();

            var mockSet = GetUserMockSet(users);

            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);

            var result = service.GetUsers();

            Assert.Equal(3, result.Count);
            Assert.True(result.Exists(f => f.Firstname == "John"));
        }

        private Mock<DbSet<LoginInfo>> GetLoginMockSet(IQueryable<LoginInfo> logins)
        {
            var mockSet = new Mock<DbSet<LoginInfo>>();
            mockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Provider).Returns(logins.Provider);
            mockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Expression).Returns(logins.Expression);
            mockSet.As<IQueryable<LoginInfo>>().Setup(m => m.ElementType).Returns(logins.ElementType);
            mockSet.As<IQueryable<LoginInfo>>().Setup(m => m.GetEnumerator()).Returns(logins.GetEnumerator());

            return mockSet;
        }

        private Mock<DbSet<User>> GetUserMockSet(IQueryable<User> users)
        {
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            return mockSet;
        }

        private UserWithLogin CreateAddUser()
        {
            UserWithLogin addUser = new UserWithLogin()
            {
                Firstname = "James",
                Lastname = "Smith",
                AccessRights = "Teacher",
                Email = "james.smith@email.com",
                Username = "smith123",
                Password = "Password123"
            };

            return addUser;
        }
    }
}
