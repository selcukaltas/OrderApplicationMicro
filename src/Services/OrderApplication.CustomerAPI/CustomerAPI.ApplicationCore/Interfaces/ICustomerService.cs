using Core.Utilities.Results;
using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using CustomerAPI.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Interfaces
{
    public interface ICustomerService
    {
        Task<IDataResult<CustomerOutputDto>> GetById(Guid Id);

        Task<IDataResult<List<CustomerOutputDto>>> GetAllAsync();
        Task<IResult> CreateAsync(CustomerCreateDto customerDto);

        Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto);

        Task<IResult> DeleteAsync(Guid customerId);

        Task<DataResult<bool>> ValidateAsync(Guid id);
    }
}
