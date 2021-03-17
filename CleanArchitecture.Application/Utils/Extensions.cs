using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Utils
{
    public static class Extensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
            int page, int pageSize) where T : class
        {
            var result = new PagedResult<T> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static PagedResult<T> GetPaged<T>(this IList<T> query,
            int page, int pageSize) where T : class
        {
            var result = new PagedResult<T> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }


}
