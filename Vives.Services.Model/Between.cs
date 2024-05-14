using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives.Services.Model
{
    public class Between<T>
    where T:struct
    {
        public T? From { get; set; }
        public bool IncludeFrom { get; set; } = true;
        public T? To { get; set; }
        public bool IncludeTo { get; set; } = true;
    }
}
