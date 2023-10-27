using MarquesaReplenish.Manager.DTO;

namespace MarquesaReplenish.API.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            if (pagination.RecordsNumber > 0)
            {
                return queryable
                .Skip((pagination.Page - 1) * pagination.RecordsNumber)
                .Take(pagination.RecordsNumber);
            }

            return queryable;
        }
    }
}
