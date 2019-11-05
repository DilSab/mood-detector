namespace Model.Entity
{
    public struct AddUser
    {
        public string Username;
        public string Password;
        public string Email;
        public string Firstname;
        public string Lastname;
        public string AccessRights;

        public AddUser(
            string username,
            string password,
            string email,
            string firstname,
            string lastname,
            string accessRights
        )
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.AccessRights = accessRights;
        }
    }
}
