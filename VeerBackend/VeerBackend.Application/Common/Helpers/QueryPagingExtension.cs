using VeerBackend.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace VeerBackend.Application.Common.Helpers;

// extension for creating pagination, it won't be used in our case
public static class QueryPagingExtension
{
    public static async Task<(IQueryable<TEntity> paginatedQuery, PaginationMetadata paginationMetadata)>
        PaginateQuery<TEntity>(this IQueryable<TEntity> queryable, int page = 1)
        where TEntity : notnull
    {
        var totalItems = await queryable.CountAsync();
        var paginationMetadata = new PaginationMetadata(totalItems, page);
        return (
            queryable.Skip((paginationMetadata.CurrentPage - 1) * PaginationMetadata.PageSize)
                .Take(PaginationMetadata.PageSize), paginationMetadata);
    }
}