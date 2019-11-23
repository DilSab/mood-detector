using ControllerProject.Service;
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
                new LoginInfo { Id = 1, UserId = 1, Username = "smith123", Email = "james.smith@email.com", Salt = "salt", Hash = "hash" },
                new LoginInfo { Id = 2, UserId = 2, Username = "linda1", Email = "linda.williams@email.com", Salt = "salt", Hash = "hash" },
            }.AsQueryable();

            var loginMockSet = new Mock<DbSet<LoginInfo>>();
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Provider).Returns(loginData.Provider);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.Expression).Returns(loginData.Expression);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.ElementType).Returns(loginData.ElementType);
            loginMockSet.As<IQueryable<LoginInfo>>().Setup(m => m.GetEnumerator()).Returns(loginData.GetEnumerator());

            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.LoginInfoes).Returns(loginMockSet.Object);

            var mockEncryptor = new Mock<IEncryptor>();
            mockEncryptor.Setup(c => c.IsHashMathing("hash", "Password123", "salt")).Returns(true);

            var service = new LoginAuthenticator(mockContext.Object, mockEncryptor.Object);

            Assert.False(service.IsLoginCorrect("", ""));
            Assert.False(service.IsLoginCorrect("smith123", ""));
            Assert.False(service.IsLoginCorrect("", "Password123"));

            Assert.True(service.IsLoginCorrect("smith123", "Password123"));
        }
    }
}
