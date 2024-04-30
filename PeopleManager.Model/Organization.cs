using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Model
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "organization name")]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
