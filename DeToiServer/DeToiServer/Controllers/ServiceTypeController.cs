﻿using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Services.ServiceTypeService;
using DeToiServerCore.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/service-type")]
    public class ServiceTypeController : Controller
    {
        private readonly IServiceTypeService _service;
        private readonly UnitOfWork _uow;

        public ServiceTypeController(IServiceTypeService service, UnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetServiceTypeDto>>> GetServices()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetServiceTypeDto>> GetServiceById(int id)
        {
            var serviceType = await _service.GetById(id);

            if (serviceType is null)
            {
                return BadRequest(new
                {
                    Message = "Không thể tìm thấy dịch vụ!"
                });
            }

            return Ok(serviceType);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceType>> CreateService(PostServiceTypeDto serviceTypeDto)
        {
            var serviceType = await _service.Add(serviceTypeDto);
            await _uow.SaveChangesAsync();
            return CreatedAtAction(nameof(GetServiceById), new { id = serviceType.Id }, serviceType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(PutServiceTypeDto putServiceTypeDto)
        {
            await _service.Update(putServiceTypeDto);
            await _uow.SaveChangesAsync();
            return Ok(new { Message = "Cập nhật dịch vụ thành công" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _service.Delete(id);
            await _uow.SaveChangesAsync();
            return NoContent();
        }
    }
}