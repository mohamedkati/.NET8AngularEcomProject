namespace API.Helpers
{
    public record PaginationResult<T>(int Count, int PageSize, int PageIndex, IReadOnlyList<T> Data) where T : class;
}
