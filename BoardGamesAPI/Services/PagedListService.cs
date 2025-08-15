//using Microsoft.EntityFrameworkCore;

//namespace BoardGamesAPI.Services
//{
//    public class PagedListService<T>(List<T> items, int page, int pageSize, int totalCount)
//    {
//        public List<T> Items { get; } = items;

//        public int Page { get; } = page;

//        public int PageSize { get; } = pageSize;

//        public int TotalCount { get; } = totalCount;

//        public bool HasNextPage => Page * PageSize < TotalCount;

//        public bool HasPreviousPage => PageSize > 1;

//        public static async Task<PagedListService<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
//        {
//            var totalCount = await query.CountAsync();

//            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

//            return new PagedListService<T>(items, page, pageSize, totalCount);
//        }


//    }
//}
