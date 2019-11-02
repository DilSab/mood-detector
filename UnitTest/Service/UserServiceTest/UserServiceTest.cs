using Moq;
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
            AddUser user = CreateAddUser();
            service.AddNewUser(user);

            mockSet.Verify(m => m.Add(It.IsAny<LoginInfo>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        private AddUser CreateAddUser()
        {
            AddUser addUser = new AddUser()
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

        [Fact]
        public void TestGetUser()
        {
            var userData = new List<User>
            {
                new User { Id = 1, Firstname = "James", Lastname = "Smith", AccessRights = "Teacher" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var loginData = new List<LoginInfo>
            {
                new LoginInfo { Id = 1, UserId = 1, Username = "smith123", Email = "james.smith@email.com", Password = "Password123" },
            }.AsQueryable();

            var loginMockSet = new Mock<DbSet<LoginInfo>>();
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Provider).Returns(loginData.Provider);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Expression).Returns(loginData.Expression);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.ElementType).Returns(loginData.ElementType);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.GetEnumerator()).Returns(loginData.GetEnumerator());
            
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
    }
}
