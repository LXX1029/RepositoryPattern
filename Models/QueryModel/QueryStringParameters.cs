using System;
using System.Collections.Generic;
using System.Text;

namespace Models.QueryModel
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        /// <summary>
        /// 每页显示数据条目数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}
