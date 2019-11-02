using ControllerProject.Service;
using Model;
using Model.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace UnitTest.Service.MoodServiceTest
{
    public class MoodServiceTest
    {
        [Fact]
        public void TestAddSession()
        {
            var mockSet = new Mock<DbSet<Session>>();

            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(m => m.Sessions).Returns(mockSet.Object);

            var service = new MoodService(mockContext.Object);
            SessionInfo sessionInfo = CreateSessionInfo();
            service.AddSession(sessionInfo);

            mockSet.Verify(m => m.Add(It.IsAny<Session>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void TestAddMood()
        {
            var mockSet = new Mock<DbSet<Mood>>();

            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(m => m.Moods).Returns(mockSet.Object);

            var service = new MoodService(mockContext.Object);
            MoodCollection moodCollection = CreateMoodCollection();
            service.AddMood(1, moodCollection);

            mockSet.Verify(m => m.Add(It.IsAny<Mood>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void TestGetMoodsByDate()
        {
            var moodData = new List<Mood>
            {
                new Mood { Id = 1, SessionId = 1, Joy = 100 },
                new Mood { Id = 2, SessionId = 2, Joy = 100 },
                new Mood { Id = 3, SessionId = 2, Joy = 100 },
            }.AsQueryable();

            var moodMockSet = new Mock<DbSet<Mood>>();
            moodMockSet.As<IQueryable<Mood>>().Setup(m => m.Provider).Returns(moodData.Provider);
            moodMockSet.As<IQueryable<Mood>>().Setup(m => m.Expression).Returns(moodData.Expression);
            moodMockSet.As<IQueryable<Mood>>().Setup(m => m.ElementType).Returns(moodData.ElementType);
            moodMockSet.As<IQueryable<Mood>>().Setup(m => m.GetEnumerator()).Returns(moodData.GetEnumerator());

            var sessionData = new List<Session>
            {
                new Session { Id = 1, UserId = 1, DateTime = new DateTime(2019, 10, 13) },
                new Session { Id = 2, UserId = 1, DateTime = new DateTime(2019, 10, 11) },
            }.AsQueryable();

            var sessionMockSet = new Mock<DbSet<Session>>();
            sessionMockSet.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(sessionData.Provider);
            sessionMockSet.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(sessionData.Expression);
            sessionMockSet.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(sessionData.ElementType);
            sessionMockSet.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(sessionData.GetEnumerator());


            var mockContext = new Mock<MoodDetectorDBEntities>();
            mockContext.Setup(c => c.Moods).Returns(moodMockSet.Object);
            mockContext.Setup(c => c.Sessions).Returns(sessionMockSet.Object);

            var service = new MoodService(mockContext.Object);

            var moods = service.GetMoodsByDate(GetSampleUser(1, "James", "Smith", "Teacher"), new DateTime(2019, 10, 12));

            Assert.Null(moods);

            moods = service.GetMoodsByDate(GetSampleUser(2, "Linda", "Williams", "Teacher"));

            Assert.Null(moods);

            moods = service.GetMoodsByDate(GetSampleUser(1, "James", "Smith", "Teacher"), new DateTime(2019, 10, 13));

            Assert.NotNull(moods);
            Assert.Equal(1, moods[0].Id);
            Assert.Equal(100, moods[0].Joy);
            Assert.Equal(1, moods[0].SessionId);

            moods = service.GetMoodsByDate(GetSampleUser(1, "James", "Smith", "Teacher"), new DateTime(2019, 10, 11));

            Assert.Equal(2, moods.Count);

            moods = service.GetMoodsByDate(GetSampleUser(1, "James", "Smith", "Teacher"));

            Assert.Equal(3, moods.Count);
        }

        [Fact]
        public void TestGetMoodAverage()
        {
            List<Mood> moods = GetSampleMoods();

            var mockContext = new Mock<MoodDetectorDBEntities>();
            var service = new MoodService(mockContext.Object);

            var moodCollection = service.GetMoodAverage(moods);

            Assert.Equal(typeof(MoodCollection), moodCollection.GetType());
            Assert.Equal(50, moodCollection.Joy);
        }

        private SessionInfo CreateSessionInfo()
        {
            DateTime dateTime = new DateTime(2019, 10, 13);
            SessionInfo sessionInfo = new SessionInfo()
            {
                User = GetSampleUser(1, "James", "Smith", "Teacher"),
                Subject = "Maths",
                Class = "1C",
                Comments = "Test comment",
                DateTime = dateTime,
            };

            return sessionInfo;
        }

        private MoodCollection CreateMoodCollection()
        {
            MoodCollection moodCollection = new MoodCollection
            {
                Anger = 100,
                Contempt = 100,
                Disgust = 100,
                Engagement = 100,
                Fear = 100,
                Joy = 100,
                Sadness = 100,
                Suprise = 100,
                Valence = 100,
            };

            return moodCollection;
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

        private List<Mood> GetSampleMoods()
        {
            List<Mood> moods = new List<Mood>
            {
                new Mood()
                {
                    Id = 1,
                    SessionId = 1,
                    Anger = 100,
                    Contempt = 100,
                    Disgust = 100,
                    Engagement = 100,
                    Fear = 100,
                    Joy = 100,
                    Sadness = 100,
                    Suprise = 100,
                    Valence = 100,
                },
                new Mood()
                {
                    Id = 2,
                    SessionId = 1,
                    Anger = 0,
                    Contempt = 0,
                    Disgust = 0,
                    Engagement = 0,
                    Fear = 0,
                    Joy = 0,
                    Sadness = 0,
                    Suprise = 0,
                    Valence = 0,
                },
            };

            return moods;
        }
    }
}
