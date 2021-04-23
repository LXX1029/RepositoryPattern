using AspNetCore_NlogTest.Contracts;
using AutoMapper;
using Contracts;
using Entities;
using Entities.Configuration;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.OptionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly ILogger<OwnerController> _logger;
        private readonly ILoggerManager _loggerManager;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IOptions<OwnerOptionModel> _options;

        public OwnerController(ILogger<OwnerController> logger, ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper, IMapper mapper
            , IOptionsSnapshot<OwnerOptionModel> options)
        {
            _logger = logger;
            this._loggerManager = loggerManager;
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
            this._options = options;
            var v = options.Value;
        }
        [HttpGet]
        public async Task<ResponseDetails> GetAllOwners()
        {
            var owners = await this._repositoryWrapper.Owner.GetAllOwners();
            this._loggerManager.LogInfo("返回所有 Owner数据");
            var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return new ResponseDetails
            {
                Message = SUCCESS,
                Data = ownersDto
            };
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwners([FromBody] OwnerParameters ownerParameters)
        {
            if (ownerParameters == null)
                return new ResponseDetails
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = PARAM_NULL_ERROR
                };

            // 参数判断在前端或者后端返回
            if (ownerParameters.MinYearOfBirth != null && ownerParameters.MaxYearOfBirth != null && !ownerParameters.ValidYearRang)
            {
                return new ResponseDetails
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = INNTER_SERVER_ERROR
                };
            }
            var owners = await this._repositoryWrapper.Owner.GetOwners(ownerParameters);
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
            var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return new ResponseDetails { Code = (int)HttpStatusCode.OK, Data = ownersDto, Pagination = pagination };
        }

        [HttpGet]
        public async Task<ResponseDetails> GetOwnerById(Guid ownerId)
        {
            var owner = await this._repositoryWrapper.Owner.GetOwnerById(ownerId);
            if (owner == null)
            {
                return new ResponseDetails { Code = (int)HttpStatusCode.NotFound, Message = NOT_FOND };
            }
            else
            {
                var ownerDto = this._mapper.Map<OwnerDto>(owner);
                return new ResponseDetails { Data = ownerDto, Message = SUCCESS };
            }
        }
        [HttpGet("{ownerId}")]
        public async Task<ResponseDetails> GetOwnerWithDetails(Guid ownerId)
        {
            var owner = await this._repositoryWrapper.Owner.GetOwnerWithDetails(ownerId);
            if (owner == null)
            {
                return new ResponseDetails { Code = (int)HttpStatusCode.NotFound, Message = NOT_FOND };
            }
            else
            {
                var ownerDto = this._mapper.Map<OwnerDto>(owner);
                return new ResponseDetails { Data = ownerDto, Message = SUCCESS };
            }
        }

        [HttpPost]
        public async Task<ResponseDetails> CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            if (owner == null)
            {
                _loggerManager.LogError("参数为空");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = PARAM_NULL_ERROR };
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var ownerEntity = this._mapper.Map<Owner>(owner);
            var _isExist = this._repositoryWrapper.Owner.IsExistOwnerName(ownerEntity);
            if (_isExist)
            {
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = "该名称已存在" };
            }
            this._repositoryWrapper.Owner.CreateOwner(ownerEntity);
            await this._repositoryWrapper.SaveAsync();
            var createdOwner = this._mapper.Map<OwnerDto>(ownerEntity);
            return new ResponseDetails { Code = (int)HttpStatusCode.Created, Data = createdOwner, Message = SUCCESS };
        }


        [HttpPost]
        public async Task<ResponseDetails> UpdateOwner([FromBody] OwnerForUpdateDto owner)
        {
            if (owner == null)
            {
                _loggerManager.LogError("参数为空");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = PARAM_NULL_ERROR };
            }
            if (!ModelState.IsValid)
            {
                this._loggerManager.LogError("参数格式不正确");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var ownerEntity = await this._repositoryWrapper.Owner.GetOwnerById(owner.OwnerId);
            if (ownerEntity == null)
            {
                this._loggerManager.LogDebug($"不存在Id为：{owner.OwnerId}的对象");
                return new ResponseDetails { Code = (int)HttpStatusCode.NotFound, Message = $"不存在Id为：{owner.OwnerId}的对象" };
            }
            var _isExist = this._repositoryWrapper.Owner.IsExistOwnerName(ownerEntity);
            if (_isExist)
            {
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = "该名称已存在" };
            }
            this._mapper.Map(owner, ownerEntity);
            this._repositoryWrapper.Owner.UpdateOwner(ownerEntity);
            await this._repositoryWrapper.SaveAsync();
            var updatedOwner = this._mapper.Map<OwnerDto>(ownerEntity);
            return new ResponseDetails { Data = updatedOwner, Message = SUCCESS };


        }
        [HttpDelete]
        public async Task<ResponseDetails> DeleteOwner(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out Guid result))
            {
                _loggerManager.LogError("传入参数不合法");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = PARAM_FORMAT_ERROR };
            }
            var owner = await this._repositoryWrapper.Owner.GetOwnerById(id);
            if (owner == null)
            {
                return new ResponseDetails { Code = (int)HttpStatusCode.NotFound, Message = $"不存在Id为：{owner.OwnerId}的对象" };
            }
            if (this._repositoryWrapper.Account.AccountsByOwner(id).Any())
            {
                _loggerManager.LogError("该owner 下存在 account 信息，请先删除 account!");
                return new ResponseDetails { Code = (int)HttpStatusCode.BadRequest, Message = "该owner 下存在 account 信息，请先删除 account!" };
            }
            this._repositoryWrapper.Owner.DeleteOwner(owner);
            await this._repositoryWrapper.SaveAsync();
            return new ResponseDetails { Message = SUCCESS };

        }
    }
}
