using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Organization;

namespace PeopleManager.Services.Extensions.Filters
{
    public static class OrganizationFilterExtensions
    {
        public static IQueryable<OrganizationResult> ApplyFilter(this IQueryable<OrganizationResult> query,
            OrganizationFilter? filter)
        {
            if (filter is null)
            {
                return query;
            }

            if (filter.NumberOfPeopleBetween is not null)
            {
                query = query.Where(o =>
                    (!filter.NumberOfPeopleBetween.From.HasValue
                     || (filter.NumberOfPeopleBetween.IncludeFrom
                         ? o.NumberOfMembers >= filter.NumberOfPeopleBetween.From
                         : o.NumberOfMembers > filter.NumberOfPeopleBetween.From)
                    )
                    && (!filter.NumberOfPeopleBetween.To.HasValue
                        || (filter.NumberOfPeopleBetween.IncludeTo
                            ? o.NumberOfMembers <= filter.NumberOfPeopleBetween.To
                            : o.NumberOfMembers < filter.NumberOfPeopleBetween.To))
                );
            }

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(o =>
                    o.Name.Contains(filter.Search)
                    || (o.Description != null && o.Description.Contains(filter.Search)));
            }

            return query;
        }
    }
}
