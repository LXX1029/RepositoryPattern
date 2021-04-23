using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
