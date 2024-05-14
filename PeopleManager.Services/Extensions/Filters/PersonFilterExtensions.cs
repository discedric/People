using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Person;

namespace PeopleManager.Services.Extensions.Filters
{
    public static class PersonFilterExtensions
    {
        public static IQueryable<PersonResults> ApplyFilter(this IQueryable<PersonResults> query, PersonFilter filter)
        {
            if (filter is null)
            {
                return query;
            }

            if (filter.OrganizationId.HasValue)
            {
                query = query.Where(x => x.OrganizationId == filter.OrganizationId);
            }

            if(!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(p =>
                    p.FirstName.Contains(filter.Search)
                    || p.LastName.Contains(filter.Search)
                    || (p.Email != null && p.Email.Contains(filter.Search))
                    || (p.OrganizationName != null && p.OrganizationName.Contains(filter.Search)));
            }

            return query;
        }
    }
}
