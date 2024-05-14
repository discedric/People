using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Services.Model;

namespace Vives.Services.Extensions
{
    public static class PagingQueryExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, Paging pagingQuery)
        {
            if (pagingQuery.Offset < 0)
            {
                pagingQuery.Offset = 0;
            }

            if (pagingQuery.Limit <= 0)
            {
                pagingQuery.Limit = 1;
            }

            if (pagingQuery.Limit > 1000)
            {
                pagingQuery.Limit = 1000;
            }

            return query
                .Skip(pagingQuery.Offset)
                .Take(pagingQuery.Limit);
        }
    }
}
