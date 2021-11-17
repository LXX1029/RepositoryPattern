using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Models
{
    /// <summary>
    /// 响应消息详细类
    /// </summary>
    public class ResponseDetails
    {
        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;
        private string message;
        /// <summary>
        /// 响应消息文本
        /// </summary>
        public string Message
        {
            get
            {
                //message = Code switch
                //{
                //    HttpStatusCode.Continue => throw new NotImplementedException(),
                //    HttpStatusCode.SwitchingProtocols => throw new NotImplementedException(),
                //    HttpStatusCode.Processing => throw new NotImplementedException(),
                //    HttpStatusCode.EarlyHints => throw new NotImplementedException(),
                //    HttpStatusCode.OK => "操作成功",
                //    HttpStatusCode.Created => "创建成功",
                //    HttpStatusCode.Accepted => throw new NotImplementedException(),
                //    HttpStatusCode.NonAuthoritativeInformation => throw new NotImplementedException(),
                //    HttpStatusCode.NoContent => throw new NotImplementedException(),
                //    HttpStatusCode.ResetContent => throw new NotImplementedException(),
                //    HttpStatusCode.PartialContent => throw new NotImplementedException(),
                //    HttpStatusCode.MultiStatus => throw new NotImplementedException(),
                //    HttpStatusCode.AlreadyReported => throw new NotImplementedException(),
                //    HttpStatusCode.IMUsed => throw new NotImplementedException(),
                //    HttpStatusCode.Ambiguous => throw new NotImplementedException(),
                //    HttpStatusCode.Moved => throw new NotImplementedException(),
                //    HttpStatusCode.Found => throw new NotImplementedException(),
                //    HttpStatusCode.RedirectMethod => throw new NotImplementedException(),
                //    HttpStatusCode.NotModified => throw new NotImplementedException(),
                //    HttpStatusCode.UseProxy => throw new NotImplementedException(),
                //    HttpStatusCode.Unused => throw new NotImplementedException(),
                //    HttpStatusCode.RedirectKeepVerb => throw new NotImplementedException(),
                //    HttpStatusCode.PermanentRedirect => throw new NotImplementedException(),
                //    HttpStatusCode.BadRequest => "非法请求",
                //    HttpStatusCode.Unauthorized => throw new NotImplementedException(),
                //    HttpStatusCode.PaymentRequired => throw new NotImplementedException(),
                //    HttpStatusCode.Forbidden => throw new NotImplementedException(),
                //    HttpStatusCode.NotFound => "所请求的资源未找到",
                //    HttpStatusCode.MethodNotAllowed => throw new NotImplementedException(),
                //    HttpStatusCode.NotAcceptable => throw new NotImplementedException(),
                //    HttpStatusCode.ProxyAuthenticationRequired => throw new NotImplementedException(),
                //    HttpStatusCode.RequestTimeout => "请求超时",
                //    HttpStatusCode.Conflict => throw new NotImplementedException(),
                //    HttpStatusCode.Gone => throw new NotImplementedException(),
                //    HttpStatusCode.LengthRequired => throw new NotImplementedException(),
                //    HttpStatusCode.PreconditionFailed => throw new NotImplementedException(),
                //    HttpStatusCode.RequestEntityTooLarge => throw new NotImplementedException(),
                //    HttpStatusCode.RequestUriTooLong => throw new NotImplementedException(),
                //    HttpStatusCode.UnsupportedMediaType => "不支持的媒体类型",
                //    HttpStatusCode.RequestedRangeNotSatisfiable => throw new NotImplementedException(),
                //    HttpStatusCode.ExpectationFailed => throw new NotImplementedException(),
                //    HttpStatusCode.MisdirectedRequest => throw new NotImplementedException(),
                //    HttpStatusCode.UnprocessableEntity => throw new NotImplementedException(),
                //    HttpStatusCode.Locked => throw new NotImplementedException(),
                //    HttpStatusCode.FailedDependency => throw new NotImplementedException(),
                //    HttpStatusCode.UpgradeRequired => throw new NotImplementedException(),
                //    HttpStatusCode.PreconditionRequired => throw new NotImplementedException(),
                //    HttpStatusCode.TooManyRequests => throw new NotImplementedException(),
                //    HttpStatusCode.RequestHeaderFieldsTooLarge => throw new NotImplementedException(),
                //    HttpStatusCode.UnavailableForLegalReasons => throw new NotImplementedException(),
                //    HttpStatusCode.InternalServerError => "内部服务器错误",
                //    HttpStatusCode.NotImplemented => throw new NotImplementedException(),
                //    HttpStatusCode.BadGateway => throw new NotImplementedException(),
                //    HttpStatusCode.ServiceUnavailable => throw new NotImplementedException(),
                //    HttpStatusCode.GatewayTimeout => throw new NotImplementedException(),
                //    HttpStatusCode.HttpVersionNotSupported => throw new NotImplementedException(),
                //    HttpStatusCode.VariantAlsoNegotiates => throw new NotImplementedException(),
                //    HttpStatusCode.InsufficientStorage => throw new NotImplementedException(),
                //    HttpStatusCode.LoopDetected => throw new NotImplementedException(),
                //    HttpStatusCode.NotExtended => throw new NotImplementedException(),
                //    HttpStatusCode.NetworkAuthenticationRequired => throw new NotImplementedException(),
                //    _ => "服务器异常",
                //};
                return message;
            }
            set
            {
                message = value;
            }
        }
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
