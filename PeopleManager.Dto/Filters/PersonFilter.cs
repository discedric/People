using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Filters
{
    public class PersonFilter
    {
        public string? Search { get; set; }
        public int? OrganizationId { get; set; }
    }
}
