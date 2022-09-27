using FianlProject.Models.Base;

namespace FianlProject.Models
{
    public class Comment:BaseEntity
    {
        public string Text { get; set; }
        public int AppUserId { get; set; }

    }
}
