using ControllerProject.Service;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace UnitTest.Service.MessageManagerTest
{
    public class MessageManagerTest
    {
        [Fact]
        public void TestAddGlobalMessage()
        {
            var mockSet = new Mock<DbSet<GlobalMessage>>();

            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(m => m.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);
            GlobalMessage message = CreateSampleMessageNotExpired("Admin");
            service.AddGlobalMessage(message);

            mockSet.Verify(m => m.Add(It.IsAny<GlobalMessage>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        
        [Fact]
        public void TestGetGlobalMessageCountByUser()
        {
            var messages = new List<GlobalMessage>
            {
                CreateSampleMessageNotExpired("Admin"),
                CreateSampleMessageNotExpired("All"),
                CreateSampleMessageNotExpired("Teacher"),
            }.AsQueryable();

            var mockSet = GetMockSet(messages);

            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);

            var count = service.GetGlobalMessageCountByUser(GetSampleUser(1, "James", "Smith", "Admin"));
            Assert.Equal(3, count);

            count = service.GetGlobalMessageCountByUser(GetSampleUser(1, "James", "Smith", "Teacher"));
            Assert.Equal(2, count);
        }

        [Fact]
        public void TestGetGlobalMessageRecipientsAllCount()
        {
            var messages = new List<GlobalMessage>
            {
                CreateSampleMessageNotExpired("Admin"),
                CreateSampleMessageNotExpired("Admin"),
                CreateSampleMessageNotExpired("All"),
                CreateSampleMessageNotExpired("Teacher"),
                CreateSampleMessageNotExpired("Teacher"),
            }.AsQueryable();

            var mockSet = GetMockSet(messages);

            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);

            var count = service.GetGlobalMessageRecipientsAllCount();
            Assert.Equal(1, count);
        }

        [Fact]
        public void TestGetRecipientGlobalMessages()
        {
            var messages = new List<GlobalMessage>
            {
                CreateSampleMessageNotExpired("Message for administrators", "Admin"),
                CreateSampleMessageNotExpired("Message for administrators", "Admin"),
                CreateSampleMessageNotExpired("Message for teachers", "Teacher"),
            }.AsQueryable();

            var mockSet = GetMockSet(messages);
            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);

            var result = service.GetRecipientGlobalMessages(GetSampleUser(1, "James", "Smith", "Teacher"));
            Assert.Equal("Message for teachers", result[0].Content);

            result = service.GetRecipientGlobalMessages(GetSampleUser(1, "James", "Smith", "Admin"));
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestGetRecipientsAllGlobalMessages()
        {
            var messages = new List<GlobalMessage>
            {
                CreateSampleMessageNotExpired("Message for administrators", "Admin"),
                CreateSampleMessageNotExpired("Message for administrators", "Admin"),
                CreateSampleMessageNotExpired("Message for teachers", "Teacher"),
                CreateSampleMessageNotExpired("Message for teachers", "Teacher"),
                CreateSampleMessageNotExpired("Message for all users", "All"),
            }.AsQueryable();

            var mockSet = GetMockSet(messages);
            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);

            var result = service.GetRecipientsAllGlobalMessages();
            Assert.Single(result);

            Assert.Equal("Message for all users", result[0].Content);
        }

        [Fact]
        public void TestDeleteGlobalMessageById()
        {
            var messages = new List<GlobalMessage>
            {
                CreateSampleMessageNotExpired(1, "", "Admin"),
            }.AsQueryable();

            var mockSet = GetMockSet(messages);
            var mockContext = new Mock<MoodDetectorDbContext>();
            mockContext.Setup(c => c.GlobalMessages).Returns(mockSet.Object);

            var service = new MessageManager(mockContext.Object);

            service.DeleteGlobalMessageById(1);

            mockSet.Verify(m => m.Remove(It.IsAny<GlobalMessage>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        private Mock<DbSet<GlobalMessage>> GetMockSet(IQueryable<GlobalMessage> messages)
        {
            var mockSet = new Mock<DbSet<GlobalMessage>>();
            mockSet.As<IQueryable<GlobalMessage>>().Setup(m => m.Provider).Returns(messages.Provider);
            mockSet.As<IQueryable<GlobalMessage>>().Setup(m => m.Expression).Returns(messages.Expression);
            mockSet.As<IQueryable<GlobalMessage>>().Setup(m => m.ElementType).Returns(messages.ElementType);
            mockSet.As<IQueryable<GlobalMessage>>().Setup(m => m.GetEnumerator()).Returns(messages.GetEnumerator());

            return mockSet;
        }

        private GlobalMessage CreateSampleMessageNotExpired(string recipientType)
        {
            GlobalMessage message = new GlobalMessage()
            {
                User = GetSampleUser(1, "James", "Smith", "Admin"),
                Content = "Message content",
                ExpirationDate = DateTime.Now.AddDays(1),
                PostedDate = new DateTime(2019, 10, 5),
                RecipientType = recipientType,
                Title = "Notice",
            };

            return message;
        }

        private GlobalMessage CreateSampleMessageNotExpired(string content, string recipientType)
        {
            GlobalMessage message = new GlobalMessage()
            {
                User = GetSampleUser(1, "James", "Smith", "Admin"),
                Content = content,
                ExpirationDate = DateTime.Now.AddDays(1),
                PostedDate = new DateTime(2019, 10, 5),
                RecipientType = recipientType,
                Title = "Notice",
            };

            return message;
        }

        private GlobalMessage CreateSampleMessageNotExpired(int id, string content, string recipientType)
        {
            GlobalMessage message = new GlobalMessage()
            {
                Id = id,
                User = GetSampleUser(1, "James", "Smith", "Admin"),
                Content = content,
                ExpirationDate = DateTime.Now.AddDays(1),
                PostedDate = new DateTime(2019, 10, 5),
                RecipientType = recipientType,
                Title = "Notice",
            };

            return message;
        }

        private User GetSampleUser(int id, string firstname, string lastname, string accessRights)
        {
            User user = new User()
            {
                Id = id,
                Firstname = firstname,
                Lastname = lastname,
                AccessRights = accessRights,
            };

            return user;
        }
    }
}
