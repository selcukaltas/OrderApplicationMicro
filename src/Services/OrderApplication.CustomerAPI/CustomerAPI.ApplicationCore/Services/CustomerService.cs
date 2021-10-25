using AutoMapper;
using Core.Utilities.Results;
using CustomerAPI.ApplicationCore.Domain.CustomerAggregate;
using CustomerAPI.ApplicationCore.Dtos;
using CustomerAPI.ApplicationCore.Interfaces;
using OrderApplication.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {   
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IAsyncRepository<Customer> customerRepository,IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<IResult> CreateAsync(CustomerCreateDto customerDto)
        {
            var customer = new Customer(customerDto.Name, customerDto.Email, customerDto.CustomerAdress);

            await _customerRepository.AddAsync(customer);

            if (customer==null)
            {
                return new ErrorResult("Something went wrong");
            }
            return new SuccessResult("Customer Successfully added");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletedCustomer =await _customerRepository.Get(x => x.Id == id);
            if (deletedCustomer != null)
            {
                await _customerRepository.DeleteAsync(deletedCustomer);
                return new SuccessResult("Customer Successfully deleted");
            }
            return new ErrorResult("Customer not found");
        }

        public async Task<IDataResult<List<CustomerOutputDto>>> GetAllAsync()
        {

            var customers = await _customerRepository.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerOutputDto>>(customers);


            if (customers.Count<=0)
            {

                return new ErrorDataResult<List<CustomerOutputDto>>(default, "Customers Not Found");
            }
            return new SuccessDataResult<List<CustomerOutputDto>>(customersDto);
        }

        public async Task<IDataResult<CustomerOutputDto>> GetById(Guid id)
        {
            var customer = await _customerRepository.Get(x => x.Id == id);

            var customerDto = _mapper.Map<CustomerOutputDto>(customer);

            if (customer != null)
            {

                return new SuccessDataResult<CustomerOutputDto>(customerDto);
            }
            return new ErrorDataResult<CustomerOutputDto>(default,"Customer not found");
        }

        public async Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var updatedCustomer = await _customerRepository.Get(x => x.Id == customerUpdateDto.Id);

            if (customerUpdateDto != null)
            {
                _mapper.Map(customerUpdateDto, updatedCustomer);

                await _customerRepository.UpdateAsync(updatedCustomer);
                return new SuccessResult("Customer succesfully updated");
            }
            return new ErrorResult("Customer not found"); 

        }

        public async Task<DataResult<bool>> ValidateAsync(Guid id)
        {
            var customerCheck = await _customerRepository.Get(x => x.Id == id);
            if (customerCheck != null)
            {
                return new SuccessDataResult<bool>(true,"Customer Validated");
            }
            return new ErrorDataResult<bool>(false,"Oops this customer is not valid");
        }
    }
}
