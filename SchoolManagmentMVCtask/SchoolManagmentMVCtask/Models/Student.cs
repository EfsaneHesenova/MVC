using Microsoft.Extensions.Primitives;

namespace SchoolManagmentMVCtask.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Group Group { get; set; }
    }
}
