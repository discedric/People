using PeopleManager.Dto.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Person;
using Vives.Services.Model;
using Vives.Services.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
    public static class PersonValidator
    {
        public static void Validate(this ServiceResult<PersonResults> serviceResult, PersonRequests request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                serviceResult.NotEmpty(nameof(request.FirstName));
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                serviceResult.NotEmpty(nameof(request.LastName));
            }

            if (request.OrganizationId == default(int))
            {
                serviceResult.NotDefault(nameof(request.OrganizationId));
            }
        }
    }
}
