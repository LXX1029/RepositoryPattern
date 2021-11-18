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
            var pagination = owners.GetPagination();
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            return ResponseSuccessWithData(owners, pagination);
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwners([FromBody] OwnerParameters ownerParameters)
        {
            if (ownerParameters == null)
                return ResponseParamIsNull();

            // 参数判断在前端或者后端返回
            if (ownerParameters.MinYearOfBirth != null && ownerParameters.MaxYearOfBirth != null && !ownerParameters.ValidYearRang)
            {
                return ResponseInnterServerError();
            }
            var owners = await this._serviceManager.OwnerService.GetOwners(ownerParameters);
            this._loggerManager.LogInfo("分页返回 Owner数据");
            var pagination = owners.GetPagination();
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            return ResponseSuccessWithData(owners, pagination);
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwnerById(Guid ownerId)
        {
            var owner = await this._serviceManager.OwnerService.GetOwnerById(ownerId);
            if (owner == null)
            {
                return ResponseNotFound();
            }
            else
            {
                return ResponseSuccessWithData(owner);
            }
        }
        [HttpGet("{ownerId}")]
        public async Task<ResponseDetails> GetOwnerWithDetails(Guid ownerId)
        {
            var owner = await this._serviceManager.OwnerService.GetOwnerWithDetails(ownerId);
            if (owner == null)
            {
                return ResponseNotFound();
            }
            else
            {
                return ResponseSuccessWithData(owner);
            }
        }

        [HttpPost]
        public async Task<ResponseDetails> CreateOwner([FromBody] OwnerForCreationDto ownerForCreationDto)
        {
            if (ownerForCreationDto == null)
            {
                _loggerManager.LogError("参数为空");
                return ResponseParamIsNull();
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return ResponseParamFormatError();
            }
            var owner = ownerForCreationDto.Adapt<OwnerDto>();
            var _isExist = await this._serviceManager.OwnerService.IsExistOwnerName(owner);
            if (_isExist)
            {
                return ResponseIsAlreadyExist($"该owner名称[{owner.Name}]已存在");
            }
            owner = await this._serviceManager.OwnerService.CreateOwnerAsync(ownerForCreationDto);

            return ResponseSuccessWithData(owner);
        }


        [HttpPost]
        public async Task<ResponseDetails> UpdateOwner([FromBody] OwnerForUpdateDto ownerForUpdate)
        {
            if (ownerForUpdate == null)
            {
                _loggerManager.LogError("参数为空");
                return ResponseParamIsNull();
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return ResponseParamFormatError();
            }
            var ownerEntity = ownerForUpdate.Adapt<OwnerDto>();

            var isExistOwner = await this._serviceManager.OwnerService.IsExistOwner(ownerEntity);
            if (!isExistOwner)
            {
                this._loggerManager.LogDebug($"不存在Id为：{ownerForUpdate.OwnerId}的对象");
                return ResponseNotFound($"不存在Id为：{ownerForUpdate.OwnerId}的对象");
            }
            var _isExist = await this._serviceManager.OwnerService.IsExistOwnerName(ownerEntity);
            if (_isExist)
            {
                return ResponseIsAlreadyExist("该名称已存在");
            }

            // var ownerEntity = ownerForUpdate.Adapt<OwnerDto>();
            var updateOwner = await this._serviceManager.OwnerService.UpdateOwnerAsync(ownerEntity);
            return ResponseSuccessWithData(ownerEntity);
        }
        [HttpDelete]
        public async Task<ResponseDetails> DeleteOwner([FromBody] OwnerDto ownerDto)
        {
            if (ownerDto == null)
            {
                _loggerManager.LogError("传入参数不合法");
                return ResponseParamFormatError();
            }
            var isExistOwner = await this._serviceManager.OwnerService.IsExistOwner(ownerDto);
            if (!isExistOwner)
            {
                return ResponseNotFound($"不存在Id为：{ownerDto.OwnerId}的数据");
            }
            //if (this._serviceManager.OwnerService.AccountsByOwner(id).Any())
            //{
            //    _loggerManager.LogError("该owner 下存在 account 信息，请先删除 account!");
            //    return new ResponseDetails { Code = HttpStatusCode.BadRequest, Message = "该owner 下存在 account 信息，请先删除 account!" };
            //}
            await this._serviceManager.OwnerService.DeleteOwnerAsync(ownerDto);
            return new ResponseDetails { Message = SUCCESS };
        }
    }
}
