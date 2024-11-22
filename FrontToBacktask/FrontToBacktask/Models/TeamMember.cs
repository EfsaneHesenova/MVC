namespace FrontToBacktask.Models
{
    public class TeamMember : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }

    }
}
