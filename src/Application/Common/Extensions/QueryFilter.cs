using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Extensions
{
    public static class QueryFilter
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static IQueryable<TSource> OrderByIf<TSource>(this IQueryable<TSource> query, bool condition, string keySelector, bool isDescending = false)
        {
            if (condition)
            {
                return query.ApplySorting(keySelector, isDescending);
            }

            return query;
        }

        public static IQueryable<TSource> ApplySorting<TSource>(this IQueryable<TSource> query, string keySelector, bool isDescending = false)
        {
            if (isDescending)
                return query.OrderBy($"{keySelector} descending");

            return query.OrderBy(keySelector);
        }
    }
}
