﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Vives.Services.Model
{
    public class ServiceResult
    {
        public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();
        public bool IsSuccess => Messages.All(m => m.Type != MessageType.Error);
    }
}
