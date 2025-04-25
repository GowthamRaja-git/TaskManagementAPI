using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int AssignedToUserId { get; set; }
        //public User AssignedTo { get; set; }
        public User? AssignedToUser { get; set; }
    }



    public class TaskItemRequest
    {

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int AssignedToUserId { get; set; }
    }

    public class UserDetails
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public Role RoleID { get; set; }
    }

    public class TaskResponse
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedToUserId { get; set; }
        public UserDetails? UserDetails { get; set; }
    }
}
