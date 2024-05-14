using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Services.Model;

namespace PeopleManager.Dto.Identity
{
    public class AuthenticationResult: ServiceResult
    {
        public string? Token { get; set; }
    }
}
