﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Services.Model;

namespace PeopleManager.Dto.Filters
{
    public class OrganizationFilter
    {
        public string? Search { get; set; }
        public Between<int>? NumberOfPeopleBetween { get; set; }
    }
}
