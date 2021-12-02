using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    /// <summary>
    /// 服务管理类接口
    /// </summary>
    public interface IServiceManager
    {
        IOwnerService OwnerService { get; }
    }
}
