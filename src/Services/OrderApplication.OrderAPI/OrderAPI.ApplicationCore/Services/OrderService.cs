using AutoMapper;
using Core.Utilities.Results;
using Newtonsoft.Json.Linq;
using OrderAPI.ApplicationCore.Domain.OrderAggregate;
using OrderAPI.ApplicationCore.Dtos;
using OrderAPI.ApplicationCore.HttpClientExtension;
using OrderAPI.ApplicationCore.Interfaces;
using OrderApplication.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> _orderRepo;
        private readonly IMapper _mapper;
        public OrderService(IAsyncRepository<Order> orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public async Task<DataResult<bool>> ChangeStatus(OrderChangeStatusDto orderChangeStatusDto)
        {
            var order = await _orderRepo.Get(x=>x.Id==orderChangeStatusDto.Id);
            if (order == null)
            {
                return new ErrorDataResult<bool>("Order can't found");
            }
            order.UpdateStatus(orderChangeStatusDto.Status);

            await _orderRepo.UpdateAsync(order);

            return new SuccessDataResult<bool>("Order status succesfully changed");
        }

        public async Task<IResult> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var customerApiDto = new CustomerApiDto();
            using (HttpClient client = HttpClientFactory.Get($"http://localhost:5002/api/Customer/GetById/{orderCreateDto.CustomerId}"))
            {
               var resultObject = await HttpClientProcess.GetCustomerData(client);
                JToken token = resultObject["data"];
                if (token.Type == JTokenType.Null)
                {
                    return new ErrorResult("There is no customer for create order");
                }
                customerApiDto = resultObject["data"].ToObject<CustomerApiDto>();
            }
            var createOrder = new Order(customerApiDto.Id, orderCreateDto.OrderAddress, orderCreateDto.Product,orderCreateDto.Quantity,orderCreateDto.Price,orderCreateDto.Status);
           await _orderRepo.AddAsync(createOrder);

           return new SuccessResult("Order succesfully created");
        }

        public async Task<IResult> DeleteAsync(Guid orderId)
        {
            var deletedOrder = await _orderRepo.Get(x => x.Id == orderId);
            if (deletedOrder != null)
            {
                await _orderRepo.DeleteAsync(deletedOrder);

                return new SuccessResult("Order successfully deleted");
            }
            return new ErrorResult("Order not found");
        }

        public async Task<IDataResult<List<OrderOutputDto>>> GetAllAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            var orderOutputDto = _mapper.Map<List<OrderOutputDto>>(orders);

            if (orders.Count <= 0)
            {
                return new ErrorDataResult<List<OrderOutputDto>>(default, "Orders Not Found");
            }
            return new SuccessDataResult<List<OrderOutputDto>>(orderOutputDto);
        }

        public async Task<IDataResult<OrderOutputDto>> GetById(Guid Id)
        {

            var order = await _orderRepo.Get(x => x.Id == Id);
            var orderOutputDto = _mapper.Map<OrderOutputDto>(order);

            if (order != null)
            {

                return new SuccessDataResult<OrderOutputDto>(orderOutputDto);
            }
            return new ErrorDataResult<OrderOutputDto>(default,"Order not found");
        }

        public async Task<DataResult<List<OrderOutputDto>>> GetOrdersByCustomerId(Guid guid)
        {
            var order = await _orderRepo.GetAllAsync(x => x.CustomerId == guid);
            var orderOutputDto = _mapper.Map<List<OrderOutputDto>>(order);

            if (order.Count >= 0)
            {

                return new SuccessDataResult<List<OrderOutputDto>>(orderOutputDto);
            }
            return new ErrorDataResult<List<OrderOutputDto>>(default, "Order not found");
        }

        public async Task<IResult> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var updatedCustomer = await _orderRepo.Get(x => x.Id == orderUpdateDto.Id);

            if (updatedCustomer != null)
            {
                _mapper.Map(updatedCustomer, updatedCustomer);

                await _orderRepo.UpdateAsync(updatedCustomer);
                return new SuccessResult("Order succesfully updated");
            }
            return new ErrorResult("Order not found");
        }

      
    }
}
