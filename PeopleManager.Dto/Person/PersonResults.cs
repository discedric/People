using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Person
{
    public class PersonResults
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        // optional
        public string? Email { get; set; }

        // if the person is part of an organization
        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }

    }
}
