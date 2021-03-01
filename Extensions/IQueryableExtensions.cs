using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medicine.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> source, bool filter, Expression<Func<T, bool>> predicate)
        {
            if (filter)
            {
                return source
                    .Where(predicate);
            }

            return source;
        }
    }
}
