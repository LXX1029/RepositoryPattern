using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Entities
{
    /// <summary>
    /// 响应消息详细类
    /// </summary>
    public class ResponseDetails
    {
        /// <summary>
        /// 响应状态码
        /// </summary>
        public int Code { get; set; } = (int)HttpStatusCode.OK;
        /// <summary>
        /// 响应消息文本
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 分页信息对象
        /// </summary>
        public object Pagination { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
