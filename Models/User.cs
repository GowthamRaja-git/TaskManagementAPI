using System.Data;

namespace TaskManagementAPI.Models
{

    public enum Role { Admin, User }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public Role Role { get; set; }
    }

    public class UserTask
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
