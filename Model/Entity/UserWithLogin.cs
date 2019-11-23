namespace Model.Entity
{
    public struct UserWithLogin
    {
        public string Username;
        public string Email;
        public string Firstname;
        public string Lastname;
        public string AccessRights;

        public UserWithLogin(
            string username,
            string email,
            string firstname,
            string lastname,
            string accessRights = "Teacher"
        )
        {
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            AccessRights = accessRights;
        }
    }
}
