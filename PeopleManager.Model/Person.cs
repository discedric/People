using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Model
{
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
        public Organization Organization { get; set; } = null!;
    }
}
