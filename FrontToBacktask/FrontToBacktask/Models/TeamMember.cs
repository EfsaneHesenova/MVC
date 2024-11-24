using FrontToBacktask.Models.Base;

namespace FrontToBacktask.Models
{
    public class TeamMember : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }

    }
}
