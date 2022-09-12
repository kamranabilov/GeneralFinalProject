using FianlProject.Models.Base;

namespace FianlProject.Models
{
    public class Setting:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
