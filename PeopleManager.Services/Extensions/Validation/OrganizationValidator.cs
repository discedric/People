using PeopleManager.Dto.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Services.Model;
using Vives.Services.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
    public static class OrganizationValidator
    {
        public static void Validate(this ServiceResult<OrganizationResult> serviceResult, OrganizationRequests request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                serviceResult.NotEmpty(nameof(request.Name));
            }
        }
    }
}
