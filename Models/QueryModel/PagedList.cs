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
        public int CurrentPage { get;  set; }
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
        public bool HasPrevious => CurrentPage > 1;
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize):base()
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
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
            var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, currentPage, pageSize);
        }
    }
}
