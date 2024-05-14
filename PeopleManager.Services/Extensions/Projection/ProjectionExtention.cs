using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Organization;
using PeopleManager.Dto.Person;
using PeopleManager.Model;

namespace PeopleManager.Services.Extensions.Projection
{
    public static class ProjectionExtention
    {
        public static IQueryable<OrganizationResult> Project(this IQueryable<Organization> query)
        {
            return query.Select(o => new OrganizationResult
            {
                Id= o.Id,
                Name = o.Name,
                Description = o.Description,
                NumberOfMembers = o.Members.Count
            });
        }

        public static IQueryable<PersonResults> Project(this IQueryable<Person> query)
        {
            return query.Select(p => new PersonResults
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                OrganizationId = p.OrganizationID,
                OrganizationName = p.Organization != null ? p.Organization.Name : null
            });
        }
    }
}
