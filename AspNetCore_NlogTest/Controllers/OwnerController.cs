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
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var owners = await this._repositoryWrapper.Owner.GetAllOwners();
                this._loggerManager.LogInfo("返回所有 Owner数据");
                var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownersDto);
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError($"发生错误：{ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners([FromBody] OwnerParameters ownerParameters)
        {
            // 参数判断在前端或者后端返回
            if (ownerParameters.MinYearOfBirth != null && ownerParameters.MaxYearOfBirth != null && !ownerParameters.ValidYearRang)
            {
                return BadRequest("最大年份应该大于最小年份");
            }
            try
            {
                var owners = this._repositoryWrapper.Owner.GetOwners(ownerParameters);
                this._loggerManager.LogInfo("分页返回 Owner数据");
                var metadata = new
                {
                    owners.TotalCount,
                    owners.PageSize,
                    owners.CurrentPage,
                    owners.TotalPages,
                    owners.HasNext,
                    owners.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(new { metadata = metadata, data = ownersDto });
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOwnerById(Guid ownerId)
        {
            try
            {
                var owner = await this._repositoryWrapper.Owner.GetOwnerById(ownerId);
                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    var ownerDto = this._mapper.Map<OwnerDto>(owner);
                    return Ok(ownerDto);
                }
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }
        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid ownerId)
        {
            try
            {
                var owner = await this._repositoryWrapper.Owner.GetOwnerWithDetails(ownerId);
                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    var ownerDto = this._mapper.Map<OwnerDto>(owner);
                    return Ok(ownerDto);
                }
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            try
            {
                if (owner == null)
                {
                    _loggerManager.LogError("参数为空");
                    return BadRequest("owner 对象为空");
                }
                if (!ModelState.IsValid)
                {
                    this._loggerManager.LogError("参数格式不正确");
                    return BadRequest("参数格式不正确");
                }
                var ownerEntity = this._mapper.Map<Owner>(owner);
                var _isExist = this._repositoryWrapper.Owner.IsExistOwnerName(ownerEntity);
                if (_isExist)
                {
                    Response.Headers.Add("error", "xxxx");
                    return StatusCode(1, "该名称已存在");
                }

                this._repositoryWrapper.Owner.CreateOwner(ownerEntity);
                await this._repositoryWrapper.SaveAsync();
                var createdOwner = this._mapper.Map<OwnerDto>(ownerEntity);
                // 创建成功，重新调用GetOwnerById或者返回 NoContent();
                return CreatedAtAction("GetOwnerById", new { ownerId = createdOwner.OwnerId }, createdOwner);

            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateOwner([FromBody] OwnerForUpdateDto owner)
        {
            try
            {
                if (owner == null)
                {
                    _loggerManager.LogError("参数为空");
                    return BadRequest("owner 对象为空");
                }
                if (!ModelState.IsValid)
                {
                    this._loggerManager.LogError("参数格式不正确");
                    return BadRequest("参数格式不正确");
                }
                var ownerEntity = await this._repositoryWrapper.Owner.GetOwnerById(owner.OwnerId);
                if (ownerEntity == null)
                {
                    this._loggerManager.LogDebug($"不存在Id为：{owner.OwnerId}的对象");
                    return NotFound($"不存在Id为：{owner.OwnerId}的对象");
                }
                var _isExist = this._repositoryWrapper.Owner.IsExistOwnerName(ownerEntity);
                if (_isExist)
                {
                    Response.Headers.Add("error", "xxxx");
                    return StatusCode(1, "该名称已存在");
                }
                this._mapper.Map(owner, ownerEntity);
                this._repositoryWrapper.Owner.UpdateOwner(ownerEntity);
                await this._repositoryWrapper.SaveAsync();
                return RedirectToAction("GetAllOwners");
                //return NoContent();

            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            try
            {
                if (!Guid.TryParse(id.ToString(), out Guid result))
                {
                    _loggerManager.LogError("传入参数不合法");
                    return Content("传入参数不合法");
                }
                var _owner = await this._repositoryWrapper.Owner.GetOwnerById(id);
                if (_owner == null)
                {
                    return NotFound();
                }
                if (this._repositoryWrapper.Account.AccountsByOwner(id).Any())
                {
                    _loggerManager.LogError("该owner 下存在 account 信息，请先删除 account!");
                    return BadRequest("该owner 下存在 account 信息，请先删除 account!");
                }
                this._repositoryWrapper.Owner.DeleteOwner(_owner);
                await this._repositoryWrapper.SaveAsync();
                return Content("删除成功");
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }
    }
}
