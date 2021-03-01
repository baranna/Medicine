using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Paging
{
    public static class PagingExtensions
    {
        public static async Task<PageResponse<T>> ToPagedListAsync<T>(this IQueryable<T> source, PageRequest pageRequest)
        {
            var result = await source
                .Skip(pageRequest.Page * pageRequest.PageSize)
                .Take(pageRequest.PageSize)
                .ToListAsync();

            var totalCount = await source.CountAsync();

            return new PageResponse<T>
            {
                Result = result,
                Page = pageRequest.Page,
                PageSize = pageRequest.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
