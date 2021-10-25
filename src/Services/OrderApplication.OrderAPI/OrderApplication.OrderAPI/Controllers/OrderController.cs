using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Dtos;
using OrderAPI.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderApplication.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _orderService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await _orderService.GetById(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(OrderCreateDto customerCreateDto)
        {
            var response = await _orderService.CreateAsync(customerCreateDto);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(OrderUpdateDto customerUpdateDto)
        {
            var response = await _orderService.UpdateAsync(customerUpdateDto);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);

        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync( Guid id)
        {
            var response = await _orderService.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(OrderChangeStatusDto changeStatusDto)
        {
            var response = await _orderService.ChangeStatus(changeStatusDto);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
        [HttpPost("GetOrdersByCustomer/{id}")]
        public async Task<IActionResult> GetOrdersByCustomer(Guid id)
        {
            var response = await _orderService.GetOrdersByCustomerId(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.NotFound, response);
        }
    }
}
