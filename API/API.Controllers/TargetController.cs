using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Abstractions;
using API.Models;
using AutoMapper;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TargetController : BaseController
    {
        private readonly ITargetService _targetService;

        public TargetController(IMapper mapper, ITargetService targetService) : base(mapper)
        {
            _targetService = targetService;
        }

        [HttpPost("create")]
        public Task<IActionResult> Create([Required] TargetModelCreate modelCreate)
        {
            return DoAction(async () => 
                await _targetService.CreateAsync(Mapper.Map<TargetDto>(modelCreate)));
        }
        
        [HttpGet("get")]
        public Task<IActionResult> Get()
        {
            return DoAction(async () => Mapper.Map<IEnumerable<TargetModel>>(await _targetService.GetAllAsync()));
        }
        
        [HttpGet("get/{guid}")]
        public Task<IActionResult> Get([Required] Guid guid)
        {
            return DoAction(async () => await _targetService.GetAsync(guid));
        }
        
        [HttpPost("edit")]
        public Task<IActionResult> Edit([Required] TargetModel modelCreate)
        {
            return DoAction(async () => 
                await _targetService.UpdateAsync(Mapper.Map<TargetDto>(modelCreate)));
        }
        
        [HttpDelete("delete/{guid}")]
        public Task<IActionResult> Remove([Required] Guid guid)
        {
            return DoAction(async () => 
                await _targetService.DeleteAsync(guid));
        }
    }
}