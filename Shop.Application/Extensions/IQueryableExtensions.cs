using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.QueryTemplates;

namespace Shop.Application.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
            {
                if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                    return query;

                if (queryObj.IsSortAscending)
                    return query.OrderBy(columnsMap[queryObj.SortBy]);
                else
                    return query.OrderByDescending(columnsMap[queryObj.SortBy]);
            }

            //public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
            //{
            //    if (queryObj.PageSize <= 0)
            //        queryObj.PageSize = 10;

            //    if (queryObj.Page <= 0)
            //        queryObj.Page = 1;

            //    return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
            //}

            public static IQueryable<T> ApplyFiltering<T, M>(this IQueryable<T> query, M filter, Dictionary<(string, bool), Expression<Func<T, bool>>> columns)
            {
            var filters = columns.Where(c => c.Key.Item2).Select(c => c.Value).ToList(); // get expressions where key is true
                if (filters.Count == 0)
                {
                    return query;
                }
                var parameterExpression = Expression.Parameter(typeof(T), "x");
                var expressionList = new List<Expression>();
                foreach (var filterExpression in filters)
                {
                    var convertedExpression = Expression.Invoke(filterExpression, parameterExpression);
                    expressionList.Add(convertedExpression);
                }
                var combinedExpression = expressionList.Aggregate(Expression.AndAlso);

                var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameterExpression);
                query = query.Where(lambda);

                return query;
                //var expression = filters.Aggregate((current, next) => current.AndAlso(next)); // combine expressions using AndAlso operator
                //query = query.Where(expression);

            //foreach (var column in columns)
            //{
            //    var expression = column.Value;
            //    var hasValue = column.Key;

            //    if (hasValue)
            //    {
            //        query = query.Where(expression);
            //    }

            //}

            //return query;
            }
        }
}
