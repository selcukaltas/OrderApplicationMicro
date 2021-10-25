using Core.Utilities.Results;
using OrderAPI.ApplicationCore.Domain.OrderAggregate;
using OrderAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<IDataResult<OrderOutputDto>> GetById(Guid Id);

        Task<IDataResult<List<OrderOutputDto>>> GetAllAsync();
        Task<IResult> CreateAsync(OrderCreateDto orderCreateDto);

        Task<IResult> UpdateAsync(OrderUpdateDto orderUpdateDto);

        Task<IResult> DeleteAsync(Guid orderId);

        Task<DataResult<bool>> ChangeStatus(OrderChangeStatusDto orderChangeStatusDto);
        Task<DataResult<List<OrderOutputDto>>> GetOrdersByCustomerId(Guid guid);
    }
}
