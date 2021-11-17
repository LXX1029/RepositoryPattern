using AspNetCore_NlogTest.Contracts;
using AutoMapper;
using Contracts5Dot0;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.QueryModel;
using Newtonsoft.Json;
using Services.Abstractions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly ILogger<OwnerController> _logger;
        private readonly ILoggerManager _loggerManager;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public OwnerController(ILogger<OwnerController> logger, ILoggerManager loggerManager, IServiceManager serviceManager, IMapper mapper
           )
        {
            _logger = logger;
            this._loggerManager = loggerManager;
            this._serviceManager = serviceManager;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseDetails> GetAllOwners()
        {
            var owners = await this._serviceManager.OwnerService.GetOwners(new Models.QueryModel.OwnerParameters());
            this._loggerManager.LogInfo("返回所有 Owner数据");
            var pagination = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            return new ResponseDetails
            {
                Message = SUCCESS,
                Data = owners,
                Pagination = pagination
            };
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwners([FromBody] OwnerParameters ownerParameters)
        {
            if (ownerParameters == null)
                return new ResponseDetails
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = PARAM_NULL_ERROR
                };

            // 参数判断在前端或者后端返回
            if (ownerParameters.MinYearOfBirth != null && ownerParameters.MaxYearOfBirth != null && !ownerParameters.ValidYearRang)
            {
                return new ResponseDetails
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = INNTER_SERVER_ERROR
                };
            }
            var owners = await this._serviceManager.OwnerService.GetOwners(ownerParameters);
            this._loggerManager.LogInfo("分页返回 Owner数据");
            var pagination = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            return new ResponseDetails { Code = HttpStatusCode.OK, Data = owners, Pagination = pagination };
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwnerById(Guid ownerId)
        {
            var owner = await this._serviceManager.OwnerService.GetOwnerById(ownerId);
            if (owner == null)
            {
                return new ResponseDetails { Code = HttpStatusCode.NotFound, Message = NOT_FOND };
            }
            else
            {
                return new ResponseDetails { Data = owner, Message = SUCCESS };
            }
        }
        [HttpGet("{ownerId}")]
        public async Task<ResponseDetails> GetOwnerWithDetails(Guid ownerId)
        {
            var owner = await this._serviceManager.OwnerService.GetOwnerWithDetails(ownerId);
            if (owner == null)
            {
                return new ResponseDetails { Code = HttpStatusCode.NotFound, Message = NOT_FOND };
            }
            else
            {
                return new ResponseDetails { Data = owner, Message = SUCCESS };
            }
        }

        [HttpPost]
        public async Task<ResponseDetails> CreateOwner([FromBody] OwnerForCreationDto ownerForCreationDto)
        {
            if (ownerForCreationDto == null)
            {
                _loggerManager.LogError("参数为空");
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = PARAM_NULL_ERROR };
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var owner = ownerForCreationDto.Adapt<OwnerDto>();
            var _isExist = await this._serviceManager.OwnerService.IsExistOwnerName(owner);
            if (_isExist)
            {
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = $"该owner名称[{owner.Name}]已存在" };
            }
            owner = await this._serviceManager.OwnerService.CreateOwnerAsync(ownerForCreationDto);

            return new ResponseDetails { Code = HttpStatusCode.Created, Data = owner };
        }


        [HttpPost]
        public async Task<ResponseDetails> UpdateOwner([FromBody] OwnerForUpdateDto ownerForUpdate)
        {
            if (ownerForUpdate == null)
            {
                _loggerManager.LogError("参数为空");
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = PARAM_NULL_ERROR };
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var ownerEntity = ownerForUpdate.Adapt<OwnerDto>();

            var isExistOwner = await this._serviceManager.OwnerService.IsExistOwner(ownerEntity);
            if (!isExistOwner)
            {
                this._loggerManager.LogDebug($"不存在Id为：{ownerForUpdate.OwnerId}的对象");
                return new ResponseDetails { Code = HttpStatusCode.NotFound, Message = $"不存在Id为：{ownerForUpdate.OwnerId}的对象" };
            }
            var _isExist = await this._serviceManager.OwnerService.IsExistOwnerName(ownerEntity);
            if (_isExist)
            {
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = "该名称已存在" };
            }

            // var ownerEntity = ownerForUpdate.Adapt<OwnerDto>();
            var updateOwner = await this._serviceManager.OwnerService.UpdateOwnerAsync(ownerEntity);
            return new ResponseDetails { Data = ownerEntity, Message = SUCCESS };


        }
        [HttpDelete]
        public async Task<ResponseDetails> DeleteOwner(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out Guid result))
            {
                _loggerManager.LogError("传入参数不合法");
                return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var owner = await this._serviceManager.OwnerService.GetOwnerById(id);
            if (owner == null)
            {
                return new ResponseDetails { Code = HttpStatusCode.NotFound, Message = $"不存在Id为：{owner.OwnerId}的对象" };
            }
            //if (this._serviceManager.OwnerService.AccountsByOwner(id).Any())
            //{
            //    _loggerManager.LogError("该owner 下存在 account 信息，请先删除 account!");
            //    return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = "该owner 下存在 account 信息，请先删除 account!" };
            //}
            await this._serviceManager.OwnerService.DeleteOwnerAsync(owner);
            return new ResponseDetails { Message = SUCCESS };

        }
    }
}
