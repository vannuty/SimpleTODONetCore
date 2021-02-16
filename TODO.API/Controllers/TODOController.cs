using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TODO.Domain.Contracts.Services;
using TODOLib.Entities;
using TODOLib.ViewModels;

namespace TODO.API.Controllers
{
    [Route("api/[controller]")]
    public class TODOController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceTODO _serviceTODO;

        public TODOController(IMapper mapper, IServiceTODO serviceTODO)
        {
            _mapper = mapper;
            _serviceTODO = serviceTODO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<TODODetail> tODODetails = _mapper.Map<List<TODODetail>>(await _serviceTODO.GetAll());
                return Ok(tODODetails);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get TODO List");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                TODODetail tODODetail = _mapper.Map<TODODetail>(await _serviceTODO.GetById(id));
                if (tODODetail == null)
                {
                    return BadRequest("TODO not found");
                }
                return Ok(tODODetail);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get a TODO");
            }
        }  

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TODOCreate tODOCreate)
        {
            try
            {
                TODOEntity tODOEntity = _mapper.Map<TODOEntity>(tODOCreate);
                await _serviceTODO.Add(tODOEntity);
                TODODetail tODOResult = _mapper.Map<TODODetail>(tODOEntity);
                return Ok(tODOResult);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add a TODO");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TODODetail tODODetail)
        {
            try
            {
                TODOEntity tODOEntity = _mapper.Map<TODOEntity>(tODODetail);
                tODOEntity = await _serviceTODO.Update(tODOEntity);

                if (tODOEntity == null)
                {
                    return BadRequest("TODO not found");
                }

                TODODetail tODOResult = _mapper.Map<TODODetail>(tODOEntity);
                return Ok(tODOResult);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update a TODO");
            }
            
        }

        [HttpDelete, Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedTODO = await _serviceTODO.Delete(id);

                if (deletedTODO == null)
                {
                    return BadRequest("TODO not found");
                }

                return Ok("TODO successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete a TODO");
            }
        }

    }
}
