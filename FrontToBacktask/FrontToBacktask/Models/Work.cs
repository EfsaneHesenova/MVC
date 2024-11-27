using FrontToBacktask.Models.Base;

namespace FrontToBacktask.Models
{
    public class Work : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
