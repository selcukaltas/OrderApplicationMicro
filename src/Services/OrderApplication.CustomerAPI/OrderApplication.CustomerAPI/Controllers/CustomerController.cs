using CustomerAPI.ApplicationCore.Dtos;
using CustomerAPI.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderApplication.CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await _customerService.GetById(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CustomerCreateDto customerCreateDto)
        {
            var response = await _customerService.CreateAsync(customerCreateDto);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync( CustomerUpdateDto customerUpdateDto)
        {
            var response = await _customerService.UpdateAsync(customerUpdateDto);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);

        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync( Guid id)
        {
            var response = await _customerService.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }

        [HttpGet("Validate/{id}")]
        public async Task<IActionResult> ValidateAsync(Guid id)
        {
            var response = await _customerService.ValidateAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
    }
}
