using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_NlogTest.Extensions;
namespace AspNetCore_NlogTest.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly string SUCCESS = "操作成功";
        protected readonly string NOT_FOND = "未查询到对象";
        protected readonly string INNTER_SERVER_ERROR = "服务内部错误";
        protected readonly string PARAM_NULL_ERROR = "参数为空";
        protected readonly string PARAM_FORMAT_ERROR = "参数为空";

        public BaseController()
        {

        }

        /// <summary>
        /// Success消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <param name="data">返回数据</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseSuccess(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.Success.GetDescription();
            return new ResponseDetails(ResponseCode.Success, message);
        }

        /// <summary>
        /// Success消息-包含数据
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <param name="data">返回数据</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseSuccessWithData(object data = null, object pagination = null, string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.Success.GetDescription();
            if (data != null && pagination != null)
                return new ResponseDetails(ResponseCode.Success, message, data, pagination);
            if (data != null)
                return new ResponseDetails(ResponseCode.Success, message, data);
 
            return new ResponseDetails(ResponseCode.Success, message);
        }


        /// <summary>
        /// NotFound消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseNotFound(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.NotFound.GetDescription();
            return new ResponseDetails(ResponseCode.NotFound, message);
        }

        /// <summary>
        /// IsAlreadyExist 消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseIsAlreadyExist(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.IsAlreadyExist.GetDescription();
            return new ResponseDetails(ResponseCode.IsAlreadyExist, message);
        }

        /// <summary>
        /// InnterServerError消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseInnterServerError(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.InnterServerError.GetDescription();
            return new ResponseDetails(ResponseCode.InnterServerError, message);
        }
        /// <summary>
        /// ParamIsNull消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseParamIsNull(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.ParamIsNull.GetDescription();
            return new ResponseDetails(ResponseCode.ParamIsNull, message);
        }
        /// <summary>
        /// ParamFormatError 消息
        /// </summary>
        /// <param name="message">自定义消息</param>
        /// <returns>ResponseDetails</returns>
        protected ResponseDetails ResponseParamFormatError(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                message = ResponseCode.ParamFormatError.GetDescription();
            return new ResponseDetails(ResponseCode.ParamFormatError, message);
        }
    }
}
