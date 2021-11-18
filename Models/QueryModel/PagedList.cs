using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.QueryModel
{
    public class PagedList<T> : List<T>
    {
        public PagedList()
        {

        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 上一页
        /// </summary>
        public int PreviousPageIndex { get; set; }
        /// <summary>
        /// 下一页
        /// </summary>
        public int NextPageIndex { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevious => CurrentPageIndex > 1;
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => CurrentPageIndex < TotalPages;
        public PagedList(List<T> items, int count, int currentPage, int pageSize) : base()
        {
            TotalCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            CurrentPageIndex = currentPage;
            if (this.HasNext) this.NextPageIndex = this.CurrentPageIndex + 1;
            if (this.HasPrevious) this.PreviousPageIndex = this.CurrentPageIndex - 1;
            AddRange(items);
        }
        /// <summary>
        /// 返回Page结果
        /// </summary>
        /// <param name="source">数据集合</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>PagedList<T></returns>
        public static PagedList<T> ToPagedList(IQueryable<T> source, int currentPage, int pageSize)
        {
            var count = source.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            if (currentPage == 0)
                currentPage = 1;
            currentPage = currentPage > 0 ? currentPage > totalPages ? 1 : currentPage : 1;
            var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, currentPage, pageSize);
        }
        public object GetPagination()
        {
            return new
            {
                this.TotalCount,
                this.PageSize,
                this.CurrentPageIndex,
                this.NextPageIndex,
                this.PreviousPageIndex,
                this.TotalPages,
                this.HasNext,
                this.HasPrevious
            };
        }
    }
}
