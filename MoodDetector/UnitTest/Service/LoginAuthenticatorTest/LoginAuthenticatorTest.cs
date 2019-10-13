using Controller.Service;
using Model;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace UnitTest.Service.LoginAuthenticatorTest
{
    public class LoginAuthenticatorTest
    {
        [Fact]
        public void TestIsLoginCorrect()
        {
            var loginData = new List<LoginInfo>
            {
                new LoginInfo { Id = 1, UserId = 1, Username = "smith123", Email = "james.smith@email.com", Password = "Password123" },
                new LoginInfo { Id = 2, UserId = 2, Username = "linda1", Email = "linda.williams@email.com", Password = "Password12" },
            }.AsQueryable();

            var loginMockSet = new Mock<DbSet<LoginInfo>>();
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Provider).Returns(loginData.Provider);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Expression).Returns(loginData.Expression);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.ElementType).Returns(loginData.ElementType);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.GetEnumerator()).Returns(loginData.GetEnumerator());

            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(c => c.LoginInfoes).Returns(loginMockSet.Object);

            var service = new LoginAuthenticator(mockContext.Object);

            Assert.False(service.IsLoginCorrect("", ""));
            Assert.False(service.IsLoginCorrect("smith123", ""));
            Assert.False(service.IsLoginCorrect("", "Password123"));
            Assert.False(service.IsLoginCorrect("smith123", "Password12"));
            Assert.False(service.IsLoginCorrect("linda1", "Password123"));

            Assert.True(service.IsLoginCorrect("smith123", "Password123"));
            Assert.True(service.IsLoginCorrect("linda1", "Password12"));
        }
    }
}
