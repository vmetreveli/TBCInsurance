using System;
using System.Collections.Generic;
namespace CleanArchitecture.Domain.Models
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;

        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {

        public PagedResult()
        {
            Results = new List<T>();
        }
        public IList<T> Results { get; set; }
    }

    public class PageFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        private DateTime? BirthDate { get; set; }
        public string PersonNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"PageIndex={PageIndex}; PageSize={PageSize}; BirthDate={BirthDate}; PersonNumber={PersonNumber}";
        }
    }
}
