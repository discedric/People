using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Model
{
    [Table(nameof(Organization))]
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "organization name")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public IList<Person> Members { get; set; } = new List<Person>();
    }
}
