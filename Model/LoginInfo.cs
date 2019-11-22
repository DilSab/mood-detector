namespace Model
{
    public class LoginInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
