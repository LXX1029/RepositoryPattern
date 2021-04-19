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
        protected readonly string INNTER_SERVER_ERROR = "服务内部错误";
    }
}
