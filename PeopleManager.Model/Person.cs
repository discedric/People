using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Model
{
    [Table(nameof(Person))]
    public class Person
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email"),EmailAddress]
        public string? Email { get; set; }

        //optional
        public int? OrganizationID { get; set; }
        public Organization? Organization { get; set; } = null!;
    }
}
