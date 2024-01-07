using FianlProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FianlProject.Models
{
    public class Setting:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
	}
}
