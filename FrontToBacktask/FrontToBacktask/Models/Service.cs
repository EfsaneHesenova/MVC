using FrontToBacktask.Models.Base;

namespace FrontToBacktask.Models
{
    public class Service : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public ICollection<Work>? Works { get; set; }
    }
}
