using Controller.Service;
using Model.Entity;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Service.RegisterAuthenticatorTest
{
    public class RegisterAuthenticatorTest
    {
        [Theory]
        [ClassData(typeof(TestAddUserData))]
        public void TestInputFromClassData(AddUser addUser, bool expectedResult)
        {
            var service = new RegisterAuthenticator();

            Assert.Equal(expectedResult, service.IsRegisterDataCorrect(addUser));
        }
    }

    public class TestAddUserData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {
                new AddUser()
                {
                    Firstname = "James",
                    Lastname = "Smith",
                    AccessRights = "Teacher",
                    Email = "james.smith@email.com",
                    Username = "smith123",
                    Password = "Password123"
                },
                true, // 1) Correct input
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Admin",
                    Email = "lindawilliams@email.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                true, // 2) Correct input
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Rights",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 3) Invalid rights
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "passWord"
                },
                false, // 4) Password must contain at least one number
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1word"
                },
                false, // 5) Password must contain at least one uppercase character
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williamsemail.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 6) Invalid email
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@emailcom",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 7) Invalid email
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 8) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 9) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 10) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "",
                    Username = "linda1",
                    Password = "pass1Word"
                },
                false, // 11) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "",
                    Password = "pass1Word"
                },
                false, // 12) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = ""
                },
                false, // 13) Input is empty
            },
            new object[] {
                new AddUser()
                {
                    Firstname = "Linda",
                    Lastname = "Williams",
                    AccessRights = "Teacher",
                    Email = "linda.williams@email.com",
                    Username = "linda1",
                    Password = "pass1Wo"
                },
                false, // 14) Password must be at least 8 characters long
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
