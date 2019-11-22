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
                new User() { Id = 5, Firstname = "Robert", Lastname = "Brown", AccessRights = "Teacher" }
            );

            context.LoginInfoes.AddOrUpdate(l => l.Id,
                new LoginInfo() { Id = 1, UserId = 1, Username = "admin", Password = "Password123", Email = "admin@mooddetector.com"},
                new LoginInfo() { Id = 2, UserId = 2, Username = "james", Password = "Password123", Email = "james@mooddetector.com"},
                new LoginInfo() { Id = 3, UserId = 3, Username = "patricia", Password = "Password123", Email = "patricia@mooddetector.com"},
                new LoginInfo() { Id = 4, UserId = 4, Username = "linda", Password = "Password123", Email = "linda@mooddetector.com"},
                new LoginInfo() { Id = 5, UserId = 5, Username = "robert", Password = "Password123", Email = "robert@mooddetector.com"}
            );
        }
    }
}
