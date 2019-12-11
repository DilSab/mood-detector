using System.Data.Entity.Migrations;

namespace Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Model.MoodDetectorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Model.MoodDetectorDbContext context)
        {
            context.Users.AddOrUpdate(u => u.Id,
                new User() { Id = 1, Firstname = "Firstname", Lastname = "Lastname", AccessRights = "Admin" },
                new User() { Id = 2, Firstname = "James", Lastname = "Smith", AccessRights = "Teacher" },
                new User() { Id = 3, Firstname = "Patricia", Lastname = "Johnson", AccessRights = "Teacher" },
                new User() { Id = 4, Firstname = "Linda", Lastname = "Williams", AccessRights = "Teacher" },
                new User() { Id = 5, Firstname = "Robert", Lastname = "Brown", AccessRights = "Teacher" },
                new User() { Id = 6, Firstname = "Michael", Lastname = "Young", AccessRights = "Teacher" },
                new User() { Id = 7, Firstname = "Johnny", Lastname = "Walker", AccessRights = "Teacher" },
                new User() { Id = 8, Firstname = "Rosalee", Lastname = "Barrett", AccessRights = "Teacher" },
                new User() { Id = 9, Firstname = "Janelle", Lastname = "Leigh", AccessRights = "Teacher" },
                new User() { Id = 10, Firstname = "Melinda", Lastname = "Chapman", AccessRights = "Teacher" },
                new User() { Id = 11, Firstname = "Alexia", Lastname = "Upsdell", AccessRights = "Teacher" },
                new User() { Id = 12, Firstname = "Drew", Lastname = "Tate", AccessRights = "Teacher" },
                new User() { Id = 13, Firstname = "Cedrick", Lastname = "Cartwright", AccessRights = "Teacher" },
                new User() { Id = 14, Firstname = "Ciara", Lastname = "Boden", AccessRights = "Teacher" },
                new User() { Id = 15, Firstname = "Rowan", Lastname = "Yard", AccessRights = "Teacher" },
                new User() { Id = 16, Firstname = "Ruth", Lastname = "Verdon", AccessRights = "Teacher" },
                new User() { Id = 17, Firstname = "Eve", Lastname = "Lunt", AccessRights = "Teacher" },
                new User() { Id = 18, Firstname = "Laila", Lastname = "Richards", AccessRights = "Teacher" },
                new User() { Id = 19, Firstname = "Marie", Lastname = "Campbell", AccessRights = "Teacher" },
                new User() { Id = 20, Firstname = "Johnathan", Lastname = "Thomson", AccessRights = "Teacher" },
                new User() { Id = 21, Firstname = "Wendy", Lastname = "Lloyd", AccessRights = "Teacher" },
                new User() { Id = 22, Firstname = "Bart", Lastname = "Amstead", AccessRights = "Teacher" },
                new User() { Id = 23, Firstname = "Carla", Lastname = "Shaw", AccessRights = "Teacher" },
                new User() { Id = 24, Firstname = "Peter", Lastname = "Taylor", AccessRights = "Teacher" },
                new User() { Id = 25, Firstname = "Phillip", Lastname = "Whatson", AccessRights = "Teacher" },
                new User() { Id = 26, Firstname = "Kurt", Lastname = "Tate", AccessRights = "Teacher" },
                new User() { Id = 27, Firstname = "Miley", Lastname = "Powell", AccessRights = "Teacher" },
                new User() { Id = 28, Firstname = "John", Lastname = "Summers", AccessRights = "Teacher" },
                new User() { Id = 29, Firstname = "William", Lastname = "Cadman", AccessRights = "Teacher" },
                new User() { Id = 30, Firstname = "Stacy", Lastname = "Hood", AccessRights = "Teacher" },
                new User() { Id = 31, Firstname = "Aeris", Lastname = "Gosling", AccessRights = "Teacher" },
                new User() { Id = 32, Firstname = "Enoch", Lastname = "Seymour", AccessRights = "Teacher" }
            );

            context.LoginInfoes.AddOrUpdate(l => l.Id,   // Password: Password123
                new LoginInfo() { Id = 1, UserId = 1, Username = "admin", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "admin@mooddetector.com" },
                new LoginInfo() { Id = 2, UserId = 2, Username = "james", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "james@mooddetector.com" },
                new LoginInfo() { Id = 3, UserId = 3, Username = "patricia", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "patricia@mooddetector.com" },
                new LoginInfo() { Id = 4, UserId = 4, Username = "linda", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "linda@mooddetector.com" },
                new LoginInfo() { Id = 5, UserId = 5, Username = "robert", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "robert@mooddetector.com" },
                new LoginInfo() { Id = 6, UserId = 6, Username = "michael", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "michael@mooddetector.com" },
                new LoginInfo() { Id = 7, UserId = 7, Username = "johnny", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "johnny@mooddetector.com" },
                new LoginInfo() { Id = 8, UserId = 8, Username = "rosalee", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "rosalee@mooddetector.com" },
                new LoginInfo() { Id = 9, UserId = 9, Username = "janelle", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "janelle@mooddetector.com" },
                new LoginInfo() { Id = 10, UserId = 10, Username = "melinda", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "melinda@mooddetector.com" },
                new LoginInfo() { Id = 11, UserId = 11, Username = "alexia", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "alexia@mooddetector.com" },
                new LoginInfo() { Id = 12, UserId = 12, Username = "drew", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "drew@mooddetector.com" },
                new LoginInfo() { Id = 13, UserId = 13, Username = "cedrick", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "cedrick@mooddetector.com" },
                new LoginInfo() { Id = 14, UserId = 14, Username = "ciara", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "ciara@mooddetector.com" },
                new LoginInfo() { Id = 15, UserId = 15, Username = "rowan", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "rowan@mooddetector.com" },
                new LoginInfo() { Id = 16, UserId = 16, Username = "ruth", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "ruth@mooddetector.com" },
                new LoginInfo() { Id = 17, UserId = 17, Username = "eve", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "eve@mooddetector.com" },
                new LoginInfo() { Id = 18, UserId = 18, Username = "laila", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "laila@mooddetector.com" },
                new LoginInfo() { Id = 19, UserId = 19, Username = "marie", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "marie@mooddetector.com" },
                new LoginInfo() { Id = 20, UserId = 20, Username = "johnathan", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "johnathan@mooddetector.com" },
                new LoginInfo() { Id = 21, UserId = 21, Username = "wendy", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "wendy@mooddetector.com" },
                new LoginInfo() { Id = 22, UserId = 22, Username = "bart", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "bart@mooddetector.com" },
                new LoginInfo() { Id = 23, UserId = 23, Username = "carla", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "carla@mooddetector.com" },
                new LoginInfo() { Id = 24, UserId = 24, Username = "peter", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "peter@mooddetector.com" },
                new LoginInfo() { Id = 25, UserId = 25, Username = "phillip", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "phillip@mooddetector.com" },
                new LoginInfo() { Id = 26, UserId = 26, Username = "kurt", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "kurt@mooddetector.com" },
                new LoginInfo() { Id = 27, UserId = 27, Username = "miley", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "miley@mooddetector.com" },
                new LoginInfo() { Id = 28, UserId = 28, Username = "john", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "john@mooddetector.com" },
                new LoginInfo() { Id = 29, UserId = 29, Username = "william", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "william@mooddetector.com" },
                new LoginInfo() { Id = 30, UserId = 30, Username = "stacy", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "stacy@mooddetector.com" },
                new LoginInfo() { Id = 31, UserId = 31, Username = "aeris", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "aeris@mooddetector.com" },
                new LoginInfo() { Id = 32, UserId = 32, Username = "enoch", Salt = "6hOaWaLZ5jq0CKf0U7fo2VnLMbp+kEiLB5+DeQ==", Hash = "Ko9m+nAQ1w6HdRY7/WVHkGDERrZZr5VD9i461LLGRy1TpBT/fVa5UlfFl2vGarSpb2IjSFwhKjbTRoCC5bjRcA==", Email = "enoch@mooddetector.com" }
            );
            context.Learnings.AddOrUpdate(l => l.Id,
                new Learning() { Id = 1, Mask = 1, EmotionName="Anger", Text = "Anger levels are too high in your classes! You have a learning assigned", Link= "https://blog.brookespublishing.com/8-anger-management-tips-for-your-students/" },
                new Learning() { Id = 2, Mask = 2, EmotionName="Disgust", Text = "Disgust levels are too high in your classes! You have a learning assigned", Link= "https://www.psychologytoday.com/us/blog/smell-life/201202/taking-control-disgust" },
                new Learning() { Id = 3, Mask = 4, EmotionName="Fear", Text = "Fear levels are too high in your classes! You have a learning assigned", Link= "https://www.facultyfocus.com/articles/teaching-and-learning/strategies-for-addressing-student-fear-in-the-classroom/" },
                new Learning() { Id = 4, Mask = 8, EmotionName="Sadness", Text = "Sadness levels are too high in your classes! You have a learning assigned", Link= "https://www.wikihow.com/Overcome-Sadness" }
            );
        }
    }
}
