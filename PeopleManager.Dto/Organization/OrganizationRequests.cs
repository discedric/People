﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Organization
{
    public class OrganizationRequests
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
