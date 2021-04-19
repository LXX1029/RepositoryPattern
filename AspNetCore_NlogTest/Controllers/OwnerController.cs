using AspNetCore_NlogTest.Contracts;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public OwnerController(ILogger<OwnerController> logger, ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _logger = logger;
            this._loggerManager = loggerManager;
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = this._repositoryWrapper.Owner.GetAllOwners();
                this._loggerManager.LogInfo("加载 Owner数据");
                var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownersDto);
            }
            catch (Exception ex)
            {
                this._loggerManager.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, INNTER_SERVER_ERROR);
            }
        }
        [HttpGet]
        public IActionResult GetOwnerById(Guid ownerId)
        {
            try
            {
                var owner = this._repositoryWrapper.Owner.GetOwnerById(ownerId);
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
    }
}
