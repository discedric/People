using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives.Services.Model
{
    public class PagedServiceResult<TEntity, TFilter> : ServiceResult<TEntity>
    {
        public Paging paging { get; set; }
        public Sorting sorting { get; set; }
        public TFilter filter { get; set; }
    }
}
